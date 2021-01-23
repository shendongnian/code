    public class ControlPad : MonoBehaviour 
    {
    	public TouchPad aPad;
    	
    	
    	public float speed = 5f;
    	public float speedRotate = 150f;
    	
    	void Update ()
    	{
    		transform.Translate (aPad.virtualAxes.x* Time.deltaTime * speed, 0 ,0f);
    		
    	}	
    
    }
