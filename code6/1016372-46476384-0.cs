        private bool _ZZInitialized = true;
        [DefaultValue(false)]
        public bool ZZInitialized
        {
            get
            {
                return _ZZInitialized;
            }
            set
            {
                _ZZInitialized = value;
                //Do what you need to do after all other properties are set.
            }
        }
