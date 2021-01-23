    using System;
    using System.ComponentModel;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class Window1 : Window, INotifyPropertyChanged
        {
            public Window1()
            {
                _windowAction = (test) =>
                {
                    test.Text = "CHANGED!";
                };
    
                InitializeComponent();
            }
    
            private Action<Test> _windowAction;
            public Action<Test> WindowAction
            {
                get { return _windowAction; }
                set
                {
                    _windowAction = value;
                    NotifyOfPropertyChange("WindowAction");
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyOfPropertyChange(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
