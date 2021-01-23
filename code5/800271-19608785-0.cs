    public Stream ProcessData(string filePath)
    {
        using(var sourceCollection = new BlockingCollection<string>())
        using(var destinationCollection = new BlockingCollection<SomeClass>())
        {
            //Create a new background task to start reading in the file
            Task.Factory.StartNew(() => ReadInFile(filePath, sourceCollection), TaskCreationOptions.LongRunning);
            //Create a new background task to process the read in lines as they come in
            Task.Factory.StartNew(() => TransformToClass(sourceCollection, destinationCollection), TaskCreationOptions.LongRunning);
            //Process the newly created objects as they are created on the same thread that we originally called the function with
            return TrasformToStream(destinationCollection);
        }
    }
    private static void ReadInFile(string filePath, BlockingCollection<string> collection)
    {
        foreach(var line in File.ReadLines(filePath))
        {
            collection.Add(line);
        }
        //This lets the consumer know that we will not be adding any more items to the collection.
        collection.CompleteAdding();
    }
    private static void TransformToClass(BlockingCollection<string> source, BlockingCollection<SomeClass> dest)
    {
        //GetConsumingEnumerable() will take items out of the collection and block the thread if there are no items available and CompleteAdding() has not been called yet.
        Parallel.ForEeach(source.GetConsumingEnumerable(), 
                          (line) => dest.Add(SomeClass.ExpensiveTransform(line));
      
        dest.CompleteAdding();
    }
    private static Stream TrasformToStream(BlockingCollection<SomeClass> source)
    {
        var stream = new MemoryStream();
        foreach(var record in source.GetConsumingEnumerable())
        {
            record.Seralize(stream);
        }
        return stream;
    }
