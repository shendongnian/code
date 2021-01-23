    class HealthBarGUI1 {
    
      public GameObject player;
      private Player playerScript;
    
      void Start() {
        playerScript = (Player)player.GetComponent(typeof(Player)); 
        Debug.Log(player.CurrentLife);
      }
    
    }
