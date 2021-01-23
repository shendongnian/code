    var clientSocket = (Socket)asyn.AsyncState;
    for (int i = 0; i < m_workerSocket.Count(); i++)
    {
        if (m_workerSocket[i] == clientSocket)
        {
            m_workerSocket.RemoveAt(i);
            break;
        }
    }
    clientSocket.Close()
    
