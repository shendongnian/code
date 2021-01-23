    class MainClass
    {
        public MainClass()
        {
            bot = new Bot();
            botDataProducer = BotDataProducer();
            dataQueue = new BlockingCollection<BotData>();
            consumer = Task.Factory.Run(() => ProcessData, TaskCreationOptions.LongRunning);
            producer = Task.Factory.Run(() => GenerateData, TaskCreationOptions.LongRunning);
             
        }
    
        BlockingCollection<BotData> dataQueue;
        Task consumer;
        Task producer;
        Bot bot;
        BotDataProducer botDataProducer;
        private void ProcessData()
        {
            //blocks the thread when there is no data, automatically wakes up when data is added.
            foreach(var data in dataQueue.GetConsumingEnumerable())
            {
                bot.Refresh(data);
            }
        }
        private void GenerateData()
        {
            //Assume Next() returns "false" when there will be no more data to process
            // and blocks when there is no data currently but more could come.
            while(botDataProducer.Next())
            {
                dataQueue.Add(botDataProducer.Data);
            }
            
            //This allows the foreach loop in the other thread to exit when the queue is empty.
            dataQueue.CompleteAdding();
        }
    }
