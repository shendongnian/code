    // others, plus....
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class MARK : INotifyPropertyChanged
    {
        private string _name;
        public string Name {
            get { return _name; }
            set {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    
        // by using the CallerMemberName attribute, you don't need to specify
        // the name of the property, the compiler provides it automatically
        private void RaisePropertyChanged([CallerMemberName] string propName = "")
        {
            if (string.IsNullOrWhiteSpace(propName)) { 
                throw new ArgumentNullException("propName"); 
            }
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
