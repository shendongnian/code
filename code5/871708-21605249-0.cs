    public static IObservable<Message> ReadMessages(
        Stream sourceStream,
        IScheduler scheduler = null)
    {
        int subscribed = 0;
        scheduler = scheduler ?? Scheduler.Default;	
        return Observable.Create<Message>(o =>
        {
            // Check this is the only subscription
            // more than one consumer would wreak havoc
            int previous = Interlocked.CompareExchange(ref subscribed, 1, 0);
			
            if (previous != 0)
                o.OnError(new Exception("Only one subscriber is allowed."));
            // Create a composite disposable to handle
            // disposing the stream and the scheduled tasks
            var dispose = new CompositeDisposable();
            dispose.Add(Disposable.Create(() => sourceStream.Dispose()));	
					
            // use async scheduling to allow an easy imperative implementation
            // and not block subscriber
            var schedule = scheduler.ScheduleAsync(async (ctrl, ct) =>
            {
                // we can reuse this for each message, so define outside loop
                byte[] header = new byte[4];			
               				
                // loop until subscription disposed
                while(!ct.IsCancellationRequested)
                {			
                    // read the header asynchronously (not blocking scheduler,
                    // and passing our cancellation token
                    var bytesRead = await sourceStream.ReadAsync(header, 0, 4, ct);		
                    // reading 0 bytes for header indicates stream is done
                    if(bytesRead == 0) break;
				
                    // header is constrained to 4 bytes (from OP's code)	
                    // so if we didn't read 4 bytes the stream is bad or cancelled
                    // and we are done
                    if(bytesRead != 4)
                    {
                        // we could have been cancelled
                        ct.ThrowIfCancellationRequested();
                        // otherwise it was an error in the stream
                        o.OnError(new InvalidDataException(
                            "Unexpected stream termination"));
                        return;
                    }
	
                    // parse header (from OP's code, don't ask me!!)
                    var headerLength = IPAddress.NetworkToHostOrder(
                        BitConverter.ToInt16(header, 2));				
					
                    // now read the payload
                    var payload = new byte[headerLength];
                    bytesRead = await sourceStream.ReadAsync(
                        payload, 0, headerLength, ct);
					
                    if(bytesRead != headerLength)
                    {
                        // we could have been cancelled
                        ct.ThrowIfCancellationRequested();
                        o.OnError(new InvalidDataException(
                            "Unexpected stream termination"));
                    }					
					
                    // return a new message
                    var message = new Message { PayLoad = payload };
                    o.OnNext(message);
                }
                // final check to see if we were cancelled
                ct.ThrowIfCancellationRequested();
                // otherwise we are done
                o.OnCompleted();
            });
            // ensure stream and schedule are cleaned up
            dispose.Add(schedule);
            return dispose;
        });	
    }
