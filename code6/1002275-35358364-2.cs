    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace WPFSO
    {
        public class TestViewModel : INotifyPropertyChanged
        {    
            private string _name;
            private string _name2;
            private string _name3;
            private string _name4;
    
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
    
            public string Name2
            {
                get { return _name2; }
                set
                {
                    _name2 = value;
                    OnPropertyChanged();
                }
            }
    
            public string Name3
            {
                get { return _name3; }
                set
                {
                    _name3 = value;
                    OnPropertyChanged();
                }
            }
    
            public string Name4
            {
                get { return _name4; }
                set
                {
                    _name4 = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
