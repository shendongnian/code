    var subscription = timeout.Subscribe(
      _ => { }
      exception =>
        Tracer.Warning("Eventing Consumer timeout : {0}", exception.Message)
      );
    subscription.Dispose(); // This is bad
