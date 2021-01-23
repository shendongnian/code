        var bufferBlock = new BufferBlock<string>();
        // Write to and read from the message block concurrently. 
        var post01 = Task.Run(() =>
        {
            // Loads the Buffer
            for (int i = 0; i < 10; i++)
            {
                bufferBlock.Post(string.Format("This is a message {0}",i));
            }
        });
        var receive = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                var message = bufferBlock.Receive();
                message.Dump();
            }
        });
       
       
        Task.WaitAll(post01, receive);
