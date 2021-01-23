    void Consume()
    {
        var completedMre = new ManualResetEvent(false);
        producer.StatOperation(completedMre);
        completedMre.WaitOne(); // blocking wait
        Console.WriteLine(producer.DeqeueResult());
    }
