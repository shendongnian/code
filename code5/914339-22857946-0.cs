    public class A: INotifyPropertyChanged
    {
        //Event used to announce a change inside a property of your class
        public event PropertyChangedEventHandler PropertyChanged;
        int _x = 0;
        public int X
        {
            get { return _x; }
            set 
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged("X"); //invokes the event.
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Increase()
        {
            X++;    //use the property to invoke a property changed event.
        }
    }
    public class B
    {
        A a;
        public B()
        {
            a = new A();
            a.PropertyChanged += new PropertyChangedEventHandler(a_PropertyChanged);    //subscribe up to the event. (use -= to unsubscribe)
        }
        //Catch the event
        void a_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //execute what you would like to do.
            DoSomething();
        }
        private void DoSomething(){}
    }
