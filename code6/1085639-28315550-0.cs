    using UnityEngine;
    using System.Collections;
    public class ConnectGUI : MonoBehaviour {
    public enum ConnectionState
    {
        NotConnected,
        AttemptingConnect,
        Connected
    }
    public TCPClient client;
    public TCPServer server;
	// Use this for initialization
	void Start () 
    {
        client.connectState = ConnectionState.NotConnected;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, Screen.width - 20, 20), client.connectState.ToString());
        if (client.connectState == ConnectionState.NotConnected)
        {
            if (GUI.Button(new Rect(Screen.width * 0.5f - 200, Screen.height * 0.5f - 40, 400, 80), "Connect"))
            {
                server.StartServer();
                System.Threading.Thread.Sleep(10);
                client.StartConnect(); 
            }
        }
    }
    }
