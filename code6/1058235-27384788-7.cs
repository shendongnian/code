    private void WorkerThreadFunc(CancellationToken token)
    {
        foreach (string path in paths)
        {
            string pathCopy = path;
            if (token.IsCancellationRequested)
            {
                // you may also want to pass a timeout value here
                // to handle 'stuck' processing
                Task.WaitAll(tasks);
                return;
            }
            // note that I'm using overload with cancellation token
            var task = Task.Run(() =>
                {
                    Boolean taskResult = ProcessPicture(pathCopy);
                    return taskResult;
                }, cancellation);
            task.ContinueWith(t => result &= t.Result);
            tasks.Add(task);
        }
    }
