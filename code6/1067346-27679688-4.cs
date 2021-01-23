            Socket socket = listener.AcceptSocket();
            while (socket.Available < 4)
            {
                System.Threading.Thread.Sleep(20);
            }
            byte[] lengthBuffer = new byte[4];
            socket.Receive(lengthBuffer);
            if (BitConverter.IsLittleEndian) Array.Reverse(lengthBuffer);
            int dataLength = BitConverter.ToInt32(lengthBuffer, 0);
            while (socket.Available < dataLength)
            {
                System.Threading.Thread.Sleep(20);
            }
            byte[] dataBuffer = new byte[dataLength];
            socket.Receive(dataBuffer);
