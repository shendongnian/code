    public class myInt : INotifyPropertyChanged
        {
            public myInt(int myIntVal)
            {
                myIntProp = myIntVal;
            }
            private int iMyInt;
            public int myIntProp {
                get
                {
                    return iMyInt;
                }
                set
                {
                    iMyInt = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("myIntProp"));
                    }
                } 
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
