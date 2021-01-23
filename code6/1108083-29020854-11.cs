    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    
    public class Test : MonoBehaviour
    { 
        // Use this for initialization
        void Start()
        {
            var playerList = FindObjectOfType<PlayerList>();
                 
            playerList.PlayerTankList.Add(new PlayerList.PlayerTank(1, 2, "a player name", "black"));
        }
    }
