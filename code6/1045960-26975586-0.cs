    var sources = new List<IObservable<EMSMessageEventArgs>();     
    
    foreach(var topicSubscriber in this._topicSubscribers.ToList())
    {
        var source = Observable.FromEvent<EMSMessageHandler, EMSMessageEventArgs>(
            handler => ((sender, e) => handler(e)),
            h => topicSubscriber.MessageHandler += h,
            h => topicSubscriber.MessageHandler -= h)
            .Synchronize();
    }
    
    rawSource = sources.Merge();
