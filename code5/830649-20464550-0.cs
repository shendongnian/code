    private void MakeThreads(int n)
            {
                for (int i = 0; i < n; i++)
                {                
                    var task = Task.Factory.StartNew(PerformOperation);             
                    task.Wait();
                }
            }
