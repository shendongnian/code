            using (var stream = client.GetStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Flush();
                Console.WriteLine("Data sent.");
                stream.Read(....); //added sync read here                
            }
