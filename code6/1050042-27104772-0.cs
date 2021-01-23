    public class Person : INotifyPropertyChanged
        {
            private int _age;
            private string _name;
            public int Age
            {
                get
                {
                    return _age;
                }
                set
                {
                    if (value != _age)
                    {
                        _age = value;
                        OnPropertyChanged("Age");
                    }
                }
            }
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
                        OnPropertyChanged("Name");
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
    ViewModel is a Wrapper around the Model
    
    public class PersonViewModel : INotifyPropertyChanged
        {
           
           private Person myPerson;
           public Person MyPerson 
           { 
              get
                 {
                   if(myPerson == null)
                     myPerson=new Person { Age = 30, Name = "David" };
                 }
              set
                 {
                   myPerson=value;
                   OnPropertyChanged("MyPerson");
                 }
           }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
