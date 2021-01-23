    class SafePointerContainer
    {
        static public SafePointerContainer Instance =  new SafePointerContainer();
        public DataContainer _data;
        private SafePointerContainer() {}
        public DataContainer Data
        {
            get 
            { 
                lock(this)
                {
                    return _data;
                }
            }
            set
            {
                lock(this)
                {
                    _data = value;
                }
            }
        }
