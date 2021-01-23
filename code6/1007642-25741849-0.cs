        private int _radiusRadio;
        public int RadiusRadio
        {
            get
            {
                return _radiusRadio;
            }
            set
            {
                if (value != -1)
                {
                    if (Set(() => RadiusRadio, ref _radiusRadio, value))
                    {
                        IsDirty = true;
                    }
                }
            }
        }
