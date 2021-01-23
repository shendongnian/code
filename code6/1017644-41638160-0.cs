     private string GetResponse(NetworkStream stream)
        {
            byte[] data = new byte[1024];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                do
                {
                    stream.Read(data, 0, data.Length);
                    memoryStream.Write(data, 0, data.Length);
                } while (stream.DataAvailable);
                return Encoding.ASCII.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length);
            }
        }
