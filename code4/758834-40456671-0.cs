    string address = "127.0.0.1";
    int port = 8888;
    int connectTimeoutMilliseconds = 1000;
    
    var tcpClient = new TcpClient();
    var connectionTask = tcpClient
        .ConnectAsync(address, port).ContinueWith(task => {
            return task.IsFaulted ? null : tcpClient;
        }, TaskContinuationOptions.ExecuteSynchronously);
    var timeoutTask = Task.Delay(connectTimeoutMilliseconds)
        .ContinueWith<TcpClient>(task => null, TaskContinuationOptions.ExecuteSynchronously);
    var resultTask = Task.WhenAny(connectionTask, timeoutTask).Unwrap();
    
    resultTask.Wait();
    var resultTcpClient = resultTask.Result;
    // Or shorter by using `await`:
    // var resultTcpClient = await resultTask;
    
    if (resultTcpClient != null)
    {
        // Connected!
    }
    else
    {
        // Not connected
    }
