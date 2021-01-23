    public string WriteCommandOverTcp(string cmd)
            {
                string response = "";
                using (NetworkStream stream = tcpSocket.GetStream())
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.AutoFlush = true;
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            writer.WriteLine(cmd);
                            // If I comment the line below, the server receives the  first message
                            // otherwise it keeps waiting for data
                            response = reader.ReadLine();
                        }
                    }
                }
                return response;
            }
