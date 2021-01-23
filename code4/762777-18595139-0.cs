    public class OriginalMessage : CompositePresentationEvent<OriginalArgs> { }
    public class MyDelayedMessage : CompositePresentationEvent<MyEventArgs> { }
    
    public class DelayedMessage {
        EventAggregator _bus;
        OriginalMessage _msg;
        DispatcherTimer _timer;
        OriginalArgs _args;
    
        public DelayedMessage(
            EventAggregator bus,
            OriginalMessage sourceMessage,
            OriginalArgs args,
            TimeSpan delay
        ) {
            _bus = bus;
            _args = args;
            _msg = sourceMessage;
            _timer = new DispatcherTimer();
            _timer.Interval = delay;
            _timer.Tick += OnTimerTick;
        }
        void OnTimerTick(object sender, EventArgs args) {
            
            _bus.GetEvent<MyDelayedMessage>().Publish(_args);
        }
    }
