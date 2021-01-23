    public void OnMessageReceivedFromServer(object sender, SocketAsyncEventArgs e)
    {
        for(int i = 0; i < e.BytesTransferred; i++)
        {
            trailingBuffer.Add(e.Buffer[i]);
        }
        // handling of complete / non-complete message ...
    }
