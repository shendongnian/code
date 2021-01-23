    var observable =
      Observable.FromEventPattern<BasicDeliverEventHandler>(
        handler => _innerConsumer.Received += OnReceived,
        handler => _innerConsumer.Received -= OnReceived
        );
    var timeout = observable.Timeout(TimeSpan.FromSeconds(20));
    using (timeout.Subscribe(
      _ => { },
      exception =>
      Tracer.Warning("Eventing Consumer timeout : {0}", exception.Message)))
    {
      
    }
