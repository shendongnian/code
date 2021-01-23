    public class EventDelayer
    {
        /// <summary>
        /// Contains info on an individual event that was queued;
        /// </summary>
        public class DelayedEventInfo
        {
            private readonly object _sender;
            private readonly EventArgs _eventArgs;
            private readonly DateTime _eventTime;
            public DelayedEventInfo(object sender, EventArgs eventArgs, DateTime eventTime)
            {
                _sender = sender;
                _eventArgs = eventArgs;
                _eventTime = eventTime;
            }
            public object Sender { get { return _sender; } }
            public EventArgs EventArgs { get { return _eventArgs; } }
            public DateTime EventTime { get { return _eventTime; } }
        }
        /// <summary>
        /// contains a list of 
        /// </summary>
        public class DelayedEventArgs : EventArgs, IEnumerable<DelayedEventInfo>
        {
            private readonly List<DelayedEventInfo> _eventInfos;
            public DelayedEventArgs(IEnumerable<DelayedEventInfo> eventInfos)
            {
                _eventInfos = new List<DelayedEventInfo>(eventInfos);
            }
            public IEnumerator<DelayedEventInfo> GetEnumerator()
            {
                return _eventInfos.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _eventInfos.GetEnumerator();
            }
        }
        private readonly List<DelayedEventInfo> _infoList = new List<DelayedEventInfo>();
        private readonly TimeSpan _delayTime;
        private readonly object _lock = new object();
        private System.Threading.Timer _timer;
        public event EventHandler<DelayedEventArgs> DelayedEvent;
        public EventDelayer(TimeSpan delayTime)
        {
            _delayTime = delayTime;
        }
        /// <summary>
        /// call to 'enqueue' an event.
        /// </summary>
        public void Enqueue(object sender, EventArgs args)
        {
            lock (_lock)
            {
                _infoList.Add(new DelayedEventInfo(sender, args, DateTime.Now));
                if (_timer != null)
                {
                    _timer.Dispose();
                    _timer = null;
                }
                _timer = new System.Threading.Timer(ThreadProc, this, _delayTime, TimeSpan.FromMilliseconds(-1));
            }
        }
        /// <summary>
        /// raises the event.
        /// </summary>
        private void HandleTimer()
        {
            lock (_lock)
            {
                var ev = this.DelayedEvent;
                if (ev != null)
                {
                    DelayedEventArgs args = new DelayedEventArgs(_infoList);
                    ev(this, args);
                }
                _infoList.Clear();
            }
        }
        private static void ThreadProc(Object stateInfo)
        {
            EventDelayer thisObj = (EventDelayer)stateInfo;
            thisObj.HandleTimer();
        }
    }
    private class ExampleUsage
    {
        /// <summary>
        /// shows how to create a event delayer and use it to listen to the events from a text box and call if no further changes for 2 seconds.
        /// </summary>
        private static void ShowUsage(System.Windows.Controls.TextBox textBox)
        {
            EventDelayer eventDelayer = new EventDelayer(TimeSpan.FromSeconds(2));
            textBox.TextChanged += eventDelayer.Enqueue;
            eventDelayer.DelayedEvent += eventDelayer_DelayedEvent;
        }
        /// <summary>
        /// redo search here. if required you can access the event args originally raised from the textbox through the event args of this method
        /// </summary>
        static void eventDelayer_DelayedEvent(object sender, EventDelayer.DelayedEventArgs e)
        {
            foreach (var eventInfo in e)
            {
                var originalSender = eventInfo.Sender;
                var args = eventInfo.EventArgs;
                var timeInitiallyCalled = eventInfo.EventTime;
            }
        }
    }
