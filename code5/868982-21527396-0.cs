    //Producer
    Task.Factory.StartNew(() =>
        {
            for(int i=0;i<100000000;i++)
            {
                sendQueue.Add(new SimpleObject() { Key = "", Value = "" });
            }
            sendQueue.CompleteAdding();
        });
    //Consumer
    Task.Factory.StartNew(() =>
        {
            foreach(var so in sendQueue.GetConsumingEnumerable())
            {
                //do something
            }
        });
