    public static IObservable<Message> ReadMessages(
        Stream sourceStream,
        IScheduler scheduler = null)
    {
        int subscribed = 0;
        scheduler = scheduler ?? Scheduler.Default;
        // async flavour of create gives a nice imperative flow
        return Observable.Create<Message>(async (o, ct) =>
        {
            // first check there is only one subscriber
            // (multiple stream readers would cause havoc)
            int previous = Interlocked.CompareExchange(ref subscribed, 1, 0);
            if (previous != 0)
                o.OnError(new Exception(
                    "Only one subscriber is allowed for each stream."));
            // store the header here each time
            var header = new byte[4];
            // loop until cancellation requested
            while (!ct.IsCancellationRequested)
            {                        
                try
                {
                    // read the exact number of bytes for a header
                    await ReadExactBytesAsync(sourceStream, header, ct);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    // pass through any problem in the stream and quit
                    o.OnError(new InvalidDataException("Error in stream.", ex));
                    break;
                }                   
                ct.ThrowIfCancellationRequested();
                var bodyLength = IPAddress.NetworkToHostOrder(
                    BitConverter.ToInt16(header, 2));
                // create buffer to read the message
                var payload = new byte[bodyLength];
                // read exact bytes as before
                try
                {
                    await ReadExactBytesAsync(sourceStream, payload, ct);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    o.OnError(new InvalidDataException("Error in stream.", ex));
                    break;
                }
                // create a new message and send it to client
                var message = new Message { PayLoad = payload };
                o.OnNext(message);
            }
            // wrap things up
            ct.ThrowIfCancellationRequested();
            // this would be ingored if OnError had been sent
            o.OnCompleted();
            // we will return a disposable that cleans
            // the source stream
            return Disposable.Create(sourceStream.Close);
        });
    }
