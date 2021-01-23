    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    
    public class Test : MonoBehaviour
    { 
        // Use this for initialization
        void Start()
        {
            var playerList = FindObjectOfType<PlayerList>();
             
            var playerTank = playerList.PlayerTank;
    
            playerList.Add(new playerTank.playerTank(1, 2, "a player name", "black"));
        }
