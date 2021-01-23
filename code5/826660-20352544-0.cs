    Processor[] processors = GetProcessors(Environment.ProcessorCount);
    var queue = new ConcurrentQueue<Processor>(processors);
    Parallel.For(
        0,
        itemCount,
        new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
        item =>
        {
            // Obtain the processor
            Processor processor;
            queue.TryDequeue(out processor);
            processor.Process(item);
            // Store the processor again for another invocation
            queue.Enqueue(processor);
        }
    );
