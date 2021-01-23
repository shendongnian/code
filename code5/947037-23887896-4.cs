    using System.IO;
    using System.Net.Sockets;
    using System.Threading;
    
    namespace CTCServer
    {
        class Client
        {
            //Stores the TcpClient
            private TcpClient client;
    
            //Stores the StreamWriter. Used to write to client
            private StreamWriter writer;
    
            //Stores the StreamReader. Used to recive data from client
            private StreamReader reader;
    
            //Defines if the client shuld look for incoming data
            private bool listen = true;
    
            //Stores clientID. ClientID = clientCount on connection time
            public int id;
    
            //Event to pass recived data to the server class
            public delegate void internalGotDataFromCTCHandler(object sender, string msg);
            public event internalGotDataFromCTCHandler internalGotDataFromCTC;
    
            //Constructor
            public Client(TcpClient client, int id)
            {
                //Assain members
                this.client = client;
                this.id = id;
    
                //Init the StreamWriter
                writer = new StreamWriter(this.client.GetStream());
                reader = new StreamReader(this.client.GetStream());
    
                new Thread(() =>
                {
                    Listen(reader);
                }).Start();
            }
    
            //Reads data from the connection and fires an event wih the recived data
            public void Listen(StreamReader reader)
            {
                //While we should look for new data
                while(listen)
                {
                    //Read whole lines. This will read from start until \r\n" is recived!
                    string input = reader.ReadLine();
                    
                    //If input is null the client disconnected. Tell the user about that and close connection.
                    if (input == null)
                    {
                        //Inform user
                        input = "Client with ID " + this.id + " disconnceted.";
                        internalGotDataFromCTC(this, input);
                        
                        //Close
                        Close();
    
                        //Exit thread.
                        return;
                    }
    
                    internalGotDataFromCTC(this, input);
                }
            }
    
            //Sends the string "data" to the client
            public void Send(string data)
            {
                //Write and flush data
                writer.WriteLine(data);
                writer.Flush();
            }
    
            //Closes the connection
            public void Close()
            {
                //Stop listening
                listen = false;
    
                //Close streamwriter FIRST
                writer.Close();
    
                //Then close connection
                client.Close();
            }
        }
    }
