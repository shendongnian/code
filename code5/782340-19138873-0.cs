    BlockingCollection<item>[] _buffer = new BlockingCollection<item>();
    static void Produce()
    {
        while(true)
        {
            // Produce item;
            _buffer.Add(curItem);
        }
        // eventually stop producing
        _buffer.CompleteAdding();
    }
    static void Consume(int myIndex)
    {
        foreach (var curItem in _buffer.GetConsumingEnumerable())
        {
            // Consume item;
        }
    }
    static void main()
    {
        int N = 100;
        Thread[] consumers = new Thread[N];
        for(int i = 0; i < N; i++)
        {
            consumers[i] = new Thread(Consume);
            consumers[i].Start(i);
        }
        Thread producer = new Thread(Produce);
        producer.Start();
    }
