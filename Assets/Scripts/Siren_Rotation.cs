using UnityEngine;

public class SirenRotation : MonoBehaviour
{
    public float rotationSpeed = 180f;

    void Start()
    {
        int n = transform.childCount;
        if (n == 0) return;

        // Guardar la posicion de cada luz en el mundo y calcular su punto medio
        Vector3[] posiciones = new Vector3[n];
        Vector3 centro = Vector3.zero;
        for (int i = 0; i < n; i++)
        {
            posiciones[i] = transform.GetChild(i).position;
            centro += posiciones[i];
        }
        centro /= n;

        // Mover el pivote al centro de las luces y devolver cada luz a su sitio
        transform.position = centro;
        for (int i = 0; i < n; i++)
            transform.GetChild(i).position = posiciones[i];
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}