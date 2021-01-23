                 uint loops = 0;
                    while (true)
                    {                    
                        if (Environment.ProcessorCount == 1 || (++loops % 100) == 0)
                        {
                            processData();
                            Thread.Sleep(1);
                           
                        }
                        else
                        {
                            processData();
                            Thread.SpinWait(20);
                            
                        }
                    }
