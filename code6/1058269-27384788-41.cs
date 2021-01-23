    private List<Task> tasks = new List<Task>();
    
    private void WorkerThreadFunc(CancellationToken token)
    {
        foreach (string path in paths)
        {
            if (token.IsCancellationRequested)
            {
                // you may also want to pass a timeout value here to handle 'stuck' processing
                Task.WaitAll(tasks.ToArray());
                
                // no more new tasks
                break;
            }
            string pathCopy = path;
            var task = Task.Factory.StartNew(() =>
                {
                    Boolean taskResult = ProcessPicture(pathCopy, token); // <-- consider a cancellation here
                    return taskResult;
                }, token); // <<--- using overload with cancellation token
            task.ContinueWith(t => result &= t.Result);
            tasks.Add(task);
        }
    }
