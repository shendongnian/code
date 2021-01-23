    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Networking;
    using System.Text;
    using System.Net.Sockets;
    using System;
    using System.Net;
    
    public class Server : MonoBehaviour
    {
        //int[] ports;
        UdpClient udp; // Udp client
    
        private void Start()
        {
            udp = new UdpClient(1234);
            udp.BeginReceive(Receive, null);
        }
    
        void Send(string msg, IPEndPoint ipe)
        {
            UdpClient sC = new UdpClient(0);
            byte[] m = Encoding.Unicode.GetBytes(msg);
            sC.Send(m, msg.Length * sizeof(char), ipe);
            Debug.Log("Sending: " + msg);
            sC.Close();
        }
    
        void Receive(IAsyncResult ar)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = udp.EndReceive(ar, ref ipe);
            string msg = Encoding.Unicode.GetString(data);
            Debug.Log("Receiving: " + msg);
    
            udp.BeginReceive(Receive, null);
        }
    }
