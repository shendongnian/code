    using (m_clientSocket)
    {
        int bytes;
        while ((bytes = m_clientSocket.Receive(...)) > 0)
        {
            // process "bytes" bytes from the buffer
        }
        // other side has disconnected
    }
