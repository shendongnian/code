    public class MyMVVM : INotifyPropertyChanged
        {
            private UIElement control;
            public UIElement Control
            {
                get { return control; }
                set
                {
                    if (control == value)
                        return;
                    control = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Control"));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
