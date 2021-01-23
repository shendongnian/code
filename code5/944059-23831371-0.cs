    // An observable that will yield the next block in the stream.
    // If the resulting block length is less than blockSize, then the
    // end of the stream was reached.
    private IObservable<byte[]> ReadBlock(Stream stream, int blockSize)
    {
        // Wrap the whole thing in Defer() so that we
        // get a new memory block each time this observable is subscribed.
        return Observable.Defer(() =>
        {
            var block = new byte[blockSize];
            int numRead = 0;
            return Observable
                .Defer(() => Observable.FromAsync<int>(() =>
                    stream.ReadAsync(block, numRead, block.Length - numRead)))
                .Do(y -=> numRead += y)
                .Repeat()
                .TakeWhile(y => y > 0 && numRead != blockSize) // take until EOF or entire block is read
                .LastOrDefaultAsync()  // only emit the final result of this operation
                .Select(_ =>
                {
                    // If we hit EOF, then resize our result array to
                    // the number of bytes actually read
                    if (numRead < blockSize)
                    {
                        block = block.Take(numRead).ToArray();
                    }
                    return block;
                });
        });
    }
    public void Start()
    {
        // Subscribe to the stream for dataz.
        // Just keep reading blocks until
        // we get the final (under-sized) block
        _streamMessageContract = ReadBlock(stream, 8024)
            .Repeat()
            .TakeWhile(block => block.Length == 8024) // if block is small then that means we hit the end of the stream
            .Subscribe(
               block => _RawBytesReceived(block),
               ex => _Exception(ex),
               () => _StreamClosed());
    }
