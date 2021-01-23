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
            if (handler != null) //make sure somebody subscribed to the event
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName)); //this calls all eventhandler methods which subscribed to your classes PropertyChanged event.
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
            a.Increase()
        }
        //Catch the event
        void a_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //execute what you would like to do.
            //you can use e.PropertyName to lookup which property has actually changed.
            DoSomething();
        }
        private void DoSomething(){}
    }
