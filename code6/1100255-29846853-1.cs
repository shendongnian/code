    public Task<T> CreateMessageReceivedTask()
    {
        var taskCompletionSource = new TaskCompletionSource<T>();
        var socket=new DatagramSocket();
        socket.MessageReceived += (sender,args) =>
        {
            if(!timeout)
            {
                // ... do stuff to handle the msg
                taskCompletionSource.SetResult(<your result>);
            }
            else
            {
                //..discard the msg..
                taskCompletionSource.SetException(new Exception("Failed"));
            }
        });
    }
