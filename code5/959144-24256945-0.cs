    public class AutoMove : MonoBehaviour 
    {
      public Vector3[] points;
      ...
    
      void Update()
      {
        if(activeAutoMoveW == true)
        {
            Vector3 direction = points[i+1]-points[i];
            transform.position += direction * MoveSpeed * Time.fixedDeltaTime;
        }
        if(activeAutoMoveS == true)
        {
            Vector3 direction = points[i+1]-points[i];
            transform.position -= direction * MoveSpeed * Time.fixedDeltaTime;
        }
        ...
      }
    }
