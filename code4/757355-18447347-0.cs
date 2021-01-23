    using System.ComponentModel;
    
    namespace NotifyBubble
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            // This method is called by the Set accessor of each property. 
            // The CallerMemberName attribute that is applied to the optional propertyName 
            // parameter causes the property name of the caller to be substituted as an argument. 
            private void NotifyPropertyChanged(String propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                Person = new Person();
                Person.Salary = 100;
            }
            void PersonPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Salary")
                    NotifyPropertyChanged("CalculatedProperty");
            }
            public Double CalculatedProperty
            {
                get
                {
                    return Person.Salary / 2;
                }
            }
            private Person _person;
            public Person Person
            {
                get { return _person; }
                set
                {
                    if (Equals(value, _person)) return;
    
                    if (_person != null)
                        _person.PropertyChanged -= PersonPropertyChanged;
    
                    _person = value;
    
                    if (_person != null)
                        _person.PropertyChanged += PersonPropertyChanged;
                    NotifyPropertyChanged("Person");
                }
            }
        }
        public class Person: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            // This method is called by the Set accessor of each property. 
            // The CallerMemberName attribute that is applied to the optional propertyName 
            // parameter causes the property name of the caller to be substituted as an argument. 
            private void NotifyPropertyChanged(String propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            private double salary = 0;
            public double Salary
            { 
                get { return salary; }
                set
                {
                    if (salary == value) return;
                    salary = value;
                    NotifyPropertyChanged("Salary");
                }
            }
        }
    }
