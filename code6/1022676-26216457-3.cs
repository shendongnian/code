    static async Task Consume(BufferBlock<int> queue)
    {
        // Read messages from the block asynchronously. 
        while (await queue.OutputAvailableAsync())
        {
            IList<int> values;
            queue.TryReceive(4, out values);
            Console.WriteLine("Receiving: {0}", string.join(", ", values));
        }
    }
