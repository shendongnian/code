    class MyTask : IMyTask
    {
        private readonly ConcurrentQueue<List<SymbolsTable>> _localQueue = new ConcurrentQueue<List<SymbolsTable>>();
        private readonly Thread _thread;
        private bool _started;
    
        public void Enqueue(List<SymbolsTable> table)
        {
            _localQueue.Enqueue(table);
        }
    
        public MyTask()
        {
            _thread = new Thread(Execute);
        }
    
        public void Start()
        {
            _started = true;
            _thread.Start();
        }
    
        public void Stop()
        {
            _started = false;
        }
    
        private void Execute()
        {
            while (_started)
            {
                try
                {
                    List<SymbolsTable> list;
                    var peek = _localQueue.TryDequeue(out list);
                    if (!peek)
                    {
                        Thread.Sleep(100); //nothing to pull
                        continue;
                    }
    
                    foreach (var item in list)
                    {
                        byte[] message =
                        encoding.GetBytes((item.GetHashCode() % 100).ToString() + " " + item.SDate + "\n\r");
    
                        client.Send(message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
    }
