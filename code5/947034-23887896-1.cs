    using System.IO;
    using System.Net.Sockets;
    
    namespace CTCServer
    {
        class Client
        {
            //Stores the TcpClient
            private TcpClient client;
    
            //Stores the StreamWriter. Used to write to client
            private StreamWriter writer;
    
            //Stores clientID. ClientID = clientCount on connection time
            public int id;
    
            //Constructor
            public Client(TcpClient client, int id)
            {
                //Assain members
                this.client = client;
                this.id = id;
    
                //Init the StreamWriter
                writer = new StreamWriter(this.client.GetStream());
            }
    
            //Sends the string "data" to the client
            public void Send(string data)
            {
                writer.WriteLine(data);
                writer.Flush();
            }
    
            //Closes the connection
            public void Close()
            {
                //Close streamwriter FIRST
                writer.Close();
    
                //Then close connection
                client.Close();
            }
        }
    }
