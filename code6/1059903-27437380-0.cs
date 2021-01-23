        public partial class MainWindow : INotifyPropertyChanged
        {
            private bool m_CheckboxChecked = true;
    
            public bool CheckboxChecked
            {
                get { return m_CheckboxChecked; }
                set { m_CheckboxChecked = value; OnPropertyChanged("CheckboxChecked"); }
            }
    
            public MainWindow()
            {
                DataContext = this;
                InitializeComponent();
                CheckboxChecked = false;
            }
    
            private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
            {
                Console.WriteLine("Un-Checked");
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }
