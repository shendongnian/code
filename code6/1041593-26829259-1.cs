    namespace StackOverflow
    {
        using System.ComponentModel;
    
        public partial class MainWindow : INotifyPropertyChanged
        {
            private string loginsTextBoxText;
    
            public MainWindow()
            {
                this.InitializeComponent();
            }
    
            public string LoginsTextBoxText
            {
                get { return this.loginsTextBoxText; }
                set
                {
                    this.loginsTextBoxText = value; // Put a breakpoint here and type in the logins textbox
                    this.OnPropertyChanged(this.LoginsTextBoxText);
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName = null)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
