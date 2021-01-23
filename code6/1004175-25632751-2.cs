        public ActionController
        {
            public Connection conn;
            public ActionController(string ip, string port)
            {
                conn = new Connection(ip, port)
                conn.dataReceived += dataReceivedevent;
            }
            
            public void dataReceivedevent(Byte[] data, TcpEventArgs e)
            {
                 //Do something with the received data here
            }
            //Do everything here! the Controller is here to provide necessary information for the GUI
        }
