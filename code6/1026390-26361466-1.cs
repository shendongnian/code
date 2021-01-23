            private void PollingService()
        {
            var T = new Thread (()=>
            {
                while (true)
                {
                    if (ProcessLogIndex < ProcessLog.Count)
                    {
                        lock (this)
                        {
                            var tempList = ProcessLog.GetRange(ProcessLogIndex, ProcessLog.Count - ProcessLogIndex);
                            ProcessLogIndex = ProcessLog.Count;
                            foreach (var cell in tempList)
                            {
                                string ToSend = !string.IsNullOrEmpty(cell) ? (cell.Contains('$') ? cell.Substring(cell.LastIndexOf('$')) : cell) : "";
                                onDataOutputFromProcess(this, ToSend, Proc.ToString());
                            }
                            
                        }
                    }
                    Thread.Sleep(1000);
                }
            });
            T.IsBackground = true;
            T.Start();
        }
