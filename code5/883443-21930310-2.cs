    AutoResetEvent event;
    ...
    // in worker_DoWork
    while(!worker.CancellationPending){
        event.WaitOne();
        // Dequeue and process all queued files
    }
      
    ...
    // in Execute
    fileQueue.Enqueue(file);
    event.Set();
 
