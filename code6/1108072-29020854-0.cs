    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    
    public class Test : MonoBehaviour {
    
        public PlayerList playerList; //replace GameObject with PlayerList 
         
        // Use this for initialization
        void Start () {
             
            var playerTank = playerList.PlayerTank; // You can access it directly
    
            playerList.Add (new playerTank.playerTank(1,2,"a player name", "black")); 
        }
    
    }
