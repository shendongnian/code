    using Reactive.EventAggregator;
    MyEventAggregator.MessageAggregator = new EventAggregator();
    MyEventAggregator.MessageAggregator.GetEvent<MessageEvent>().Subscribe(se =>
    myMessageControl.Add(se)
    );
