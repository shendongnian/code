    static void Main(string[] args)
    {
        var inputBufferBlock = new BufferBlock<int>();
        var calculatorBlock = new TransformBlock<int, int>(i =>
        {
            Console.WriteLine("Calculating {0}²", i);
            return (int)Math.Pow(i, 2);
        }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 8 });
        var outputBufferBlock = new BufferBlock<int>();
        using (inputBufferBlock.LinkTo(calculatorBlock, new DataflowLinkOptions { PropagateCompletion = true }))
        using (calculatorBlock.LinkTo(outputBufferBlock, new DataflowLinkOptions { PropagateCompletion = true }))
        {
            foreach (var number in Enumerable.Range(1, 1000))
            {
                inputBufferBlock.Post(number);
            }
            inputBufferBlock.Complete();
            calculatorBlock.Completion.Wait();
            IList<int> results;
            if (outputBufferBlock.TryReceiveAll(out results))
            {
                foreach (var result in results)
                {
                    Console.WriteLine("x² = {0}", result);
                }
            }
        }
    }
