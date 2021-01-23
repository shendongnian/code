    var clientSocket = (Socket)asyn.AsyncState;
    for (int i = 0; i < m_workerSocket.Count(); i++)
    {
        if (m_workerSocket[i] == clientSocket)
        {
            var sockets = new List<Socket>(m_workerSocket);
            sockets.RemoveAt(i);
            m_workerSocket = sockets.ToArray();
            break;
        }
    }
    clientSocket.Close()
    
