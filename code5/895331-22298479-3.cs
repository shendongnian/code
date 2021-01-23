    public class DeadScreen : MonoBehaviour {
    
    	public PlayerController playerController;
    	
    	void Start() { }
    	
    	void Update() { }
    	
    	void OnMouseDown()
    	{
    	    // when user clicks inside this GameObject start the game again
    	    playerController.PlayAgain();
            Destroy(this.gameObject);
    	}
    
    }
