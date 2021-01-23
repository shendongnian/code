    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    
    namespace WpfApplication1
    {
        internal class MainViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public MainViewModel()
            {
                People = new ObservableCollection<Person>();
                DeleteCommand = new DelegateCommand(x => DeleteSelectedItem(null));
    
                People.Add(new Person { Forename = "Bob", Surname = "Smith" });
                People.Add(new Person { Forename = "Alice", Surname = "Jones" });
            }
    
            private void DeleteSelectedItem(object obj)
            {
                People.Remove(SelectedItem);
                SelectedItem = null;
            }
    
            public ICommand DeleteCommand { get; set; }
    
            public ObservableCollection<Person> People { get; set; }
    
            private Person selectedItem;
    
            public Person SelectedItem
            {
                get { return selectedItem; }
                set
                {
                    if (selectedItem == value)
                        return;
    
                    selectedItem = value;
                    OnPropertyChanged();
                }
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
