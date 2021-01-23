    private Task Receive(
            TcpClient thisClient,
            CancellationToken token)
        {
            IList<object> objects;
            while (thisClient.Connected && playerConnected == true)
            {
                try
                {
                    objects = ReadAsync<List<object>>(netStream, token);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.ToString());
                    if (thisClient.Connected == false)
                    {
                        playerConnected = false;
                        netStream.Close();
                        thisClient.Close();
                        break;
                    }
                }
                try
                {
                    foreach (var p in objects.OfType<GameObject>())
                    {
                        if (p != null)
                        {
                            mapGameObjects[p.objectID] = p;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception " + ex.ToString());
                    if (thisClient.Connected == false)
                    {
                        playerConnected = false;
                        netStream.Close();
                        break;
                    }
                }
            }
            Console.WriteLine("Receive thread closed for client.");
        }
