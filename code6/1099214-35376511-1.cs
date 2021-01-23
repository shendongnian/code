    public class testClass : INotifyPropertyChanged
    {
        private Size _testInnerSize;
        public event PropertyChangedEventHandler PropertyChanged;
        public Size testInnerSize
        {
            get
            {
                return this._testInnerSize;
            }
            set
            {
                this._testInnerSize = value;
                if (null != PropertyChanged)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("testInnerSize"));
                }
            }
        }
        public testClass()
        {
            testInnerSize = new Size(66, 99);
        }
    }
