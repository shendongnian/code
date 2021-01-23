    public void sendMessage(Socket clientSocket, string _msg)
    {
        a2 = Encoding.ASCII.GetBytes(_msg);
        networkStream = clientSocket.GetStream();
        networkStream.Write(a2, 0, a2.Length);
        networkStream.Flush();
    }
