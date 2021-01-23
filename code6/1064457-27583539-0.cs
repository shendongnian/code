        public void getNewConnection()
        {
            while (true)
            {
                try
                {
                    Socket sckReciveConnect = sckServerSocket.Accept();
                    // ...
                }
                catch (Exception)
                {
                    return; // drop out of loop
                }
            }
        }
