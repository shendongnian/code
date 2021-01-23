    private void ReadData()
        {
            //receiving server response 
            byte[] bytes = new byte[1024];
            if (networkStream.CanRead)
            {
                int bytesRead = networkStream.Read(bytes, 0, bytes.Length);                   
                //received response, now encoding it to a string from a byte array
                Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytesRead));
            }
            else
            {
                Console.WriteLine("You cannot read data from this stream.");
                tcpClient.Close();
                // Closing the tcpClient instance does not close the network stream.
                networkStream.Close();
            }
        }
