    public class MyControl : Control, ISupportInitialize
    {
        private bool _created = true;
        
        public void BeginInit()
        {
            _created = false;
        }
        public void EndInit()
        {
            _created = true;
            //check all your properties here too
        }
        
        private bool BorderShadow_ = false;
        public bool BorderShadow
        {
            get
            {
                return BorderShadow_;
            }
            set
            {
                BorderShadow_ = value;
                if (_created && Border_Style_ != BorderStyle.FixedSingle)
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
