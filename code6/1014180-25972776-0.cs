    public class customSocket : Socket
    {
        #region Properties
        private readonly Timer _timer;
        private const int _interval = 1000;
        private bool Connected
        {
            get
            {
                bool part1 = Poll(1000, SelectMode.SelectRead);
                bool part2 = (Available == 0);
                if (part1 && part2)
                    return false;
                else 
                    return true;
            }
        }
        public bool EventsEnabled
        {
            set
            {
                if (value)
                {
                    _timer.Start();
                }
                else
                    _timer.Stop();
            }
        }
        #endregion
        #region Constructors
        public customSocket(AddressFamily addressFamily, SocketType sockType, ProtocolType protocolType)
            : base(addressFamily, sockType, protocolType)
        {
            _timer = new Timer { Interval = _interval };
            _timer.Elapsed += TimerTick;
        }
        public customSocket(SocketInformation sockInfo)
            : base(sockInfo)
        {
            _timer = new Timer { Interval = _interval };
            _timer.Elapsed += TimerTick;
        }
        #endregion
        #region Events
        public event EventHandler<EventArgs> Socket_disconected;
        public void Raise_Socket_disconnected()
        {
            EventHandler<EventArgs> handler = Socket_disconected;
            if (handler != null)
            {
                handler(this,new EventArgs());
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            if (!Connected)
            {
                Raise_Socket_disconnected();
            }
        }
        #endregion
    }
