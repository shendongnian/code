    public class Session
    {
        private IList<Packet> _PacketsSequence;
        public IList<Packet> PacketsSequence
        {
            get
            {
                if (_PacketsSequence == null)
                    _PacketsSequence = new List<Packet>();
                return _PacketsSequence;
            }
            set { _PacketsSequence = value; }
        }
    }
