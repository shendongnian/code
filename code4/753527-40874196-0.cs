        public dynamic MyProperty
        {
            get { return _myProperty; }
            set
            {
                try
                {
                    _myProperty= value;
                }
                catch (Exception e)
                {
                    _myProperty= -1;
                }
            }
        }
        private int _myProperty;
