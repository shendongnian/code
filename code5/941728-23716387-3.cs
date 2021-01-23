      public partial class Window1 : Window, INotifyPropertyChanged
        {
            private int _idCounter;
            public int IdCounter
            {
                get { return _idCounter; }
                set
                {
                    if (value != _idCounter)
                    {
                        _idCounter = value;
                        OnPropertyChanged("IdCounter");
                    }
                }
            }
            public Window1()
            {
                InitializeComponent();
                myLabel.SetBinding(ContentProperty, new Binding("IdCounter"));
                DataContext = this;
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                e.Handled = true;
                IdCounter++;
            }
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string name)
            {
                var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
            #endregion
        }
