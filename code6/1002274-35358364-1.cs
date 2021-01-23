    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace WPFSO
    {
        public class SharedSizeScopeViewModel : INotifyPropertyChanged
        {
    
            public SharedSizeScopeViewModel()
            {
                var testEntries = new ObservableCollection<TestViewModel>();
                
                testEntries.Add(new TestViewModel
                {
                    Name = "Test",
                    Name2 = "Looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong test",
                    Name3 = "Short test",
                    Name4 = "Nothing"
    
                    
                });
    
                Entries = testEntries;        
            }
    
            private ObservableCollection<TestViewModel> _entries;
    
            public ObservableCollection<TestViewModel> Entries
            {
                get { return _entries; }
                set
                {
                    _entries = value; 
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
