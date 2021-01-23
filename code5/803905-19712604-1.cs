    private BlockingCollection<string> outputQueue = new BlockingCollection<string>();
    // the thread that processes information
    private void DataProcessor()
    {
        // initialization
        // process data
        while ()
        {
            string foo = CreateOutputFromData();
            // put it on the queue
            outputQueue.Add(foo);
        }
    }
    // the output thread
    private void OutputThread()
    {
        // initialize serial port
        // read data from queue until end
        string text;
        while (outputQueue.TryTake(out text, Timeout.Infinite))
        {
            // output text to serial port
        }
    }
    // main thread
    public Main()
    {
        // create the processing thread
        var processingThread = Task.Factory.StartNew(() => DataProcessor());
        // create the output thread
        var outputThread = Task.Factory.StartNew(() => OutputThread());
        // wait for user input and process
        while ()
        {
            var input = Console.ReadLine();
            // potentially process input before sending it out
            var dataToOutput = ProcessInput(input);
            // put it on the queue
            outputQueue.Add(dataToOutput);
        }
        // tell processing thread to exit
        // when you're all done, mark the queue as finished
        outputQueue.CompleteAdding();
        // wait for the threads to exit.
        Task.WaitAll(outputThread, processingThread);   
    }
