    public class PlayerController : MonoBehaviour {
        public GameObject deadScreen;
    	
    	void Start() { }
    	
    	void Update() { }
    	
    	public void ShowDeadScreen()
    	{
    		// show DeadScreen GameObject on the center of the screen
    		GameObject go = Instantiate(deadScreen, new Vector(0, 0, 0), Quaternation.Identity) as GameObject;
    		go.playerController = this;
    	}
    	
    	public void PlayAgain()
    	{
    		// handle game restart
    	}
    }
