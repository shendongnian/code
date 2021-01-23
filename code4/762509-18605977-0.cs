     private void button2_Click(object sender, EventArgs e)
        {
            if (active_clients.Count >= 0)
            {
                // active client is the list of sockets clients were connected before              
                 //server shutdown.
                active_clients.ForEach(delegate(Socket s)
                {
                    try
                    {
                        s.Shutdown(SocketShutdown.Both);
                    }
                    catch (ObjectDisposedException ex)
                    {
                        if (ex.InnerException is SocketException)
                        {
                            MessageBox.Show("some message");
                            return;
                        }
                    }
                    s.Close();
                    
                });
                active_clients.Clear();
            }
            try
            {
                serverSocket.Close();
            }
            catch (Exception)
            {
                return;
            }
        }
