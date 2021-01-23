    return Observable.Create<EventPattern<EMSMessageEventArgs>>(observer =>
    {
      EMSMessageHandler handler = (sender, e) => 
        observer.OnNext(new EventPattern<EMSMessageEventArgs>(sender, e)));
      try
      {
        _topicSubscribers.ForEach(s => s.MessageHandler += handler);
      }
      catch (Exception ex)
      {
        try
        {
          _topicSubscribers.ForEach(s => s.MessageHandler -= handler);
        }
        catch { }
        observer.OnError(ex);
      }
      return Disposable.Create(() =>
      {
        try
        {
          _topicSubscribers.ForEach(s => s.MessageHandler -= handler);
        }
        catch { }
      });
    });
