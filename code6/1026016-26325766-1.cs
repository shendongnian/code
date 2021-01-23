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
