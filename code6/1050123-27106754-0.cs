    [StructLayout(LayoutKind.Sequential)]
    public struct DN_OPstruct
    {
        private byte _direction; 
        public bool direction
        {
            get { return _direction != 0; }
            set { _direction = (byte)(value ? 1 : 0); }
        }
    }
