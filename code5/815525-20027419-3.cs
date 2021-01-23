        private readonly object _lockObj = new object();
        public void nextInstruction()
        {
            Action[] actions = 
            {
                fetch,
                decode,
                execute,
                writeBack
            };
            lock (_lockObj)
            {
                _dictActionResults.Clear();
                Parallel.Invoke(actions);
                // output the results in sequential order
                foreach (Action a in actions)
                {
                    Console.Out.WriteLine(_dictActionResults[a]);
                }
            }
        }
