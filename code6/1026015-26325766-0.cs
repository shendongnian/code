     Thread threadForClientSending = new Thread(delegate()
                {
                    while (true)
                    {
                        try
                        {
                            List<SymbolsTable> list;
                            var peek = que.TryPeek(out list);
                            if (!peek)
                            {
                                Thread.Sleep(100); //nothing to pull
                                continue;
                            }
    
                            foreach (var item in list)
                            {
                                main.que -- global queue
    
                                byte[] message =
                                encoding.GetBytes((item.GetHashCode() % 100).ToString() + " " + item.SDate + "\n\r");
    
                                client.Send(message);
    
                                Thread.Sleep(500);
                            }
    
                            counter.Signal(); //the thread would signal itself as finished, and wait for others to finish the task
                            lock (que)
                            {
                                List<SymbolsTable> lastList;
                                if (que.TryPeek(out lastList) && lastList.Equals(list))
                                {
                                    //just one of the threads would dequeue the item
                                    que.TryDequeue(out lastList);
    
                                    counter.Reset(); //reset counter for next iteration
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                    }
                });
