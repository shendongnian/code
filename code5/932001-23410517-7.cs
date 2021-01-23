    public void Scheduler()
            {
                while (true)
                {
                    ProcessQueue currentQueue = mainQueue.Dequeue();
                    int count = currentQueue.Count;
    
                    if (currentQueue.Count > 0)
                    {
                        while (count > 0)
                        {
                            Process currentProcess = currentQueue.GetNext();
                            //this wakes the thread
                            ControlEvent.Set(currentProcess.PID);
                            Thread.Sleep(quant);
                            //this makes it wait again
                            ControlEvent.Reset(currentProcess.PID);
    
                            currentQueue.Add(currentProcess);
    
                            count--;
                        }
                    }
    
                    mainQueue.Enqueue(currentQueue);
                }
            }
