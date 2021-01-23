    private void CheckIfClientStillConnectedThread(object sender, DoWorkEventArgs e)
    {
        while (socketServer != null)
        {
            int count = clientsList.Count -1;
            for (int i=count; i >= 0 ; i--)
            {
                if (clientsList[i].socket.Poll(10, SelectMode.SelectRead) && clientsList[i].socket.Available == 0)
                {
                    clientsList[i].socket.Close();
                    onClientDisconnect.Invoke(clientsList[i]);
                    clientsList.Remove(clientsList[i]);
                }
            }
            Thread.Sleep(5);
        }
    }
