    using UnityEngine;
    using System.Collections;
    
    public class NewBehaviourScript : MonoBehaviour {
    
    public string IP = "192.168.0.8";
        public int Port = "25001";
    
        void OnGUI()
        {
    
            if(Network.peerType == NetworkPeerType.Disconnected)
            {
    
                if (GUI.Button(new Rect(100,100,100,25),"Join Existing Server"))
                {
    
                Network.Connect(Ip,Port);   
    
                }
    
    
    
                if (GUI.Button(new Rect(100,125,100,25),"Create New Server"))
                {
    
                Network.InitializeServer(10,Port);
                    //First Number Above next to port in perenthisies is number of allowed clients / 1x Server (# of players allowed to join game.)
    
                }
    
                else 
                {
    
                if(Network.peerType == NetworkPeerType.Client)  
                    {
    
    
                        GUI.Label(new Rect(100,100,100,25),"Client");
                        if(GUI.Button (new Rect(100,125,100,25),"Disconnect"))
                        {
    
                            Network.Disconnect(250);
    
    
                        }
    
    
                    }
                    if(Network.peerType == NetworkPeerType.Server)
                    {
    
                        GUI.Label(new Rect(100,100,100,25),"Server");
                        GUI.Label(new Rect(100,125,100,25),"Connections: " + Network.connections.Length);
    
                        if(GUI.Button (new Rect(100,125,100,25),"Disconnect"))
                        {
    
                            Network.Disconnect(250);
    
                        }
                    }
                }
            }
        }
    }
