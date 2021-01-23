    public static IObservable<Message> ReadMessages(
        Stream sourceStream,
        IScheduler scheduler = null)
    {
        int subscribed = 0;
        scheduler = scheduler ?? Scheduler.Default;
        return Observable.Create<Message>(o =>
        {
            // first check there is only one subscriber
            // (multiple stream readers would cause havoc)
            int previous = Interlocked.CompareExchange(ref subscribed, 1, 0);
            if (previous != 0)
                o.OnError(new Exception(
                    "Only one subscriber is allowed for each stream."));
            // we will return a disposable that cleans
            // up both the scheduled task below and
            // the source stream
            var dispose = new CompositeDisposable
            {
                Disposable.Create(sourceStream.Dispose)
            };
            // use async scheduling to get nice imperative code
            var schedule = scheduler.ScheduleAsync(async (ctrl, ct) =>
            {
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
                        return;
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
                        return;
                    }
                    // create a new message and send it to client
                    var message = new Message { PayLoad = payload };
                    o.OnNext(message);
                }
                // wrap things up
                ct.ThrowIfCancellationRequested();
                o.OnCompleted();
            });
            // return the suscription handle
            dispose.Add(schedule);
            return dispose;
        });
    }
