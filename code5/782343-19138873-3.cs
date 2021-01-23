    static void Consume(item curItem)
    {
        // consume item
    }
    void Main()
    {
        Thread producer = new Thread(Produce);
        producer.Start();
        Parallel.ForEach(_buffer.GetConsumingPartitioner(), Consumer)
    }
