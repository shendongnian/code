    public class IdleManager : MonoBehaviour
    {
    	private isIdle = false;
    	private float previousTime;
    	private const float IDLE_TIME = 5.0f;
    	
    	void Update()
    	{
    		if(!isIdle && grounded && (_controller.velocity.x == 0))
    		{
    			isIdle = true;
    			previousTime = Time.timeSinceLevelLoad();
    		}
    		
    		else if(isIdle && Time.timeSinceLevelLoad - previousTime > IDLE_TIME)
    		{
    			// Play animation here.
    
    			// Reset previousTime.
    			previousTime = Time.timeSinceLevelLoad;  
    		}
    			
    		else if(grounded || _controller.velocity.x > 0)
    			isIdle = false;
    	}
    }
