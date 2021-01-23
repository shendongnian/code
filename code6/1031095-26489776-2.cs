    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var person = new Person {Name = "name1", Address = "address1"};
                person.PropertyChanged += person_PropertyChanged;
                DataContext = person;
            }
    
            private void person_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                MessageBox.Show("data changed");
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                var dataContext = (Person) DataContext;
                dataContext.Name = "newName";
                dataContext.Address = "newAddress";
            }
        }
    
        internal class Person : INotifyPropertyChanged
        {
            private string _address;
            private string _name;
    
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
    
            public string Address
            {
                get { return _address; }
                set
                {
                    _address = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
