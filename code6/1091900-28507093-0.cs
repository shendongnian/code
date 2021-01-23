    public void StartTileProcessor()
    {
        //The default for a BlockingCollection is a Queue, but you can pass in a stack for the underlying collection and it will behave as a stack.
        var stack = new BlockingCollection<UnprocessedTileMetadata>(new ConcurrentStack<UnprocessedTileMetadata>());
        var processorThread = Task.Run(() => ProcessTiles(stack));
        _yourGui.TileRequested += (sender, e) => stack.Add(e.RequestedTile);
        //...
    }
    /// <summary>
    /// The method for processing tiles, takes from the stack and returns to the output.
    /// </summary>
    /// <param name="inputStack">The blocking collection that represents the input stack.</param>
    private void ProcessTiles(BlockingCollection<UnprocessedTileMetadata> inputStack)
    {
        //This is done so the foreach does not try to buffer requests from the consuming enumerable, the next item it processes will be the last added to the stack.
        var partitioner = Partitioner.Create(inputStack.GetConsumingEnumerable(), EnumerablePartitionerOptions.NoBuffering);
        Parallel.ForEach(partitioner, (unprocessedTile) =>
        {
            ProcessedTile tile = GenerateOrGetFromCache(unprocessedTile);
            _yourGui.SendToDisplay(tile);
        });
    }
