       public string Read()
        {
            if (!tcpSocket.Connected)
            {
              throw new Exception("Socket is Closed.");
            }
            StringBuilder sb=new StringBuilder();
            do
            {
                ParseTelnet(sb);
                System.Threading.Thread.Sleep(TimeOutMs);
            } while (tcpSocket.Available > 0);
            return sb.ToString();
        }
