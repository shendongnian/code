    public IObservable<Item> ReadStream(Stream stream)
    {
      return Observable.Create<Item>(async (observer, cancel) =>
      {
        // Here's one example of reading a stream with fixed item lengths.
        var buffer = new byte[itemLength]; // TODO: Define itemLength
        var remainder = itemLength;
        int read;
        do
        {
          read = await stream.ReadAsync(buffer, itemLength - remainder, remainder, cancel)
                             .ConfigureAwait(false);
          remainder -= read;
          if (read == 0)
          {
            if (remainder < itemLength)
            {
              throw new InvalidOperationException("End of stream unexpected.");
            }
            else
            {
              break;
            }
          }
          else if (remainder == 0)
          {
            observer.OnNext(ReadItem(buffer));  // TODO: Define ReadItem
            remainder = itemLength;
          }
        }
        while (true);
      });
    }
