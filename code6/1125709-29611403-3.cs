    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    
    namespace SO
    {
        class MainModel : INotifyPropertyChanged
        {
            public ICommand ShowFindControl
            {
                get;
                set;
            }
            private Visibility _PopUpFindVisibility = Visibility.Hidden;
            public Visibility PopUpFindVisibility
            {
                get { return _PopUpFindVisibility; }
                set
                {
                    _PopUpFindVisibility = value;
                    OnPropertyChanged("PopUpFindVisibility");
                }
            }
            public MainModel()
            {
                ShowFindControl = new RelayCommand(MakeVisible);
            }
    
            private void MakeVisible(Object obj)
            {
                PopUpFindVisibility = (PopUpFindVisibility == Visibility.Hidden) ? Visibility.Visible : Visibility.Hidden;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
