    public class swipebutton : MonoBehaviour
{
    public Camera cam;
    void Update()
    {
       
        cam.transform.Rotate(Vector3.up, 20.0f * Time.deltaTime);
    }
