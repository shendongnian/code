    class MyClass : Border, INotifyPropertyChanged
    {
        private double x;
        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    RaisePropertyChanged("X");
                }
            }
        }
    
        public MyClass()
        {
            MouseMove += MyMouseMove;
        }
    
        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            var b = (Border)sender;
            X = Mouse.GetPosition(b).X;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
