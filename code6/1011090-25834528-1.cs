    namespace WpfApplication1
    {
        public class ViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private string obfuscatedPassword = "user name";
    
            public string ObfuscatedPassword
            {
                get { return obfuscatedPassword; }
                set 
                { 
                    if (this.obfuscatedPassword != value)
                    {
                        this.obfuscatedPassword = value;
                        OnPropertyChanged();
                    }
                }
            }
    
            private string actualPassword = null;
            public string ActualPassword
            {
                get { return actualPassword; }
                set
                {
                    if (this.actualPassword != value)
                    {
                        this.actualPassword = value;
                        OnPropertyChanged();
                    }
                }
            }
    
            private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
