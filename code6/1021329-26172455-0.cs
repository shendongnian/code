        public double Income
        {
            get { return _income; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format("{0} must be > 0", value));
                }
                _income = value;
                //calculate(); <<ISSUE IS HERE
            }
        }
