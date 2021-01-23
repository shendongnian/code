    public class AsyncTCP
    {
        public void StartReceive()
        {
            byte[] buffer = new byte[200];
            clientSocket.BeginReceive(buffer, 0, 200, SocketFlags.None, (state) =>
            {
                int bytesReceived = clientSocket.EndReceive(state);
                // handle buffer.
    
                if(bytesReceived != 0)
                    StartReceive();
            } ,so);
        }
    }
