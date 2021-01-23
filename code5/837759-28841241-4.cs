    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
 
    public class GameServer : MonoBehaviour 
    {
	    public List<PlayerCharacter> players = new List<PlayerCharacter>();
   	    private int playerCount = 0;
	    void OnPlayerConnected(NetworkPlayer player) 
	    {
		    networkView.RPC("CreatePlayer", player);
		    Debug.Log("Player " + playerCount + " connected from " + player.ipAddress + ":" + player.port);
	    }
	    [RPC]
	    void CreatePlayer()
	    {
		    playerCount++;
		    PlayerCharacter playerChar = new PlayerCharacter(/*player,*/ playerCount, (GameObject)Resources.Load("Player"), "Player"+playerCount, 5, 100, Vector3.zero);
		    playerChar.characterObject.AddComponent<PlayerController>().player = playerChar;
		    players.Add(playerChar);
	    }
    }
