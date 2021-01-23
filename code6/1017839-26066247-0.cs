    private AutoResetEvent autoResetEvent = new AutoResetEvent(false);
    private void Consume()
    {
       while (!myQueue.IsCompleted )
            {
                string _item = myQueue.Take();
                cancellationSignalForProcessCommandTask = new CancellationTokenSource();
                Task t = new Task(() => 
                    {
                        cancellationSignalForProcessCommandTask.Token.ThrowIfCancellationRequested();
                        DoSomeWork(_item);
                    }, cancellationSignalForProcessCommandTask.Token, TaskCreationOptions.LongRunning);
                t.Start();
                // Wait for data to be received.
                // This line will block until autoResetEvent.Set() is called.
                autoResetEvent.WaitOne();
            }
    }
    private void mySocket_ReceiveData(string dataFromServer)
    {
        string returnMessage = dataFromServer;
       // Notify other threads that data was received and that processing can continue.
       autoResetEvent.Set();
    }
