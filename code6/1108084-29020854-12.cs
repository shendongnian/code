    using System;
    using UnityEngine; 
    using System.Collections.Generic;
    
    [Serializable]
    public class PlayerList : MonoBehaviour
    {
    	public List<PlayerTank> PlayerTankList;
    
        public class PlayerTank
        { // Here is my class for PlayerTank
    
            public int playerNumber;
            public int playerPadNumber;
            public string playerName;
            public string playerColour;
    
    
            // This is a constructor to make an instance of my class. 
    
            public PlayerTank(int newPlayerNumber, int newPlayerPadNumber, string newPlayerName, string newPlayerColour)
            {
                playerNumber = newPlayerNumber;
                playerPadNumber = newPlayerPadNumber;
                playerName = newPlayerName;
                playerColour = newPlayerColour;
            }
        }
    
    
        void Awake()
        {
            PlayerTankList = new List<PlayerTank>();
        }
    
    }
