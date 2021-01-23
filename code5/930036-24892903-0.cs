    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    namespace fwWpfDataTemplate
    {
        // Classes to fill TestData
        public abstract class Person : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public class Student : Person { }
        public class Employee : Person
        {
            float _salary;
            public float Salary
            {
                get { return _salary; }
                set
                {
                    _salary = value;
                    OnPropertyChanged("Salary");
                }
            }
        }
        public class TestData : ObservableCollection<Person>
        {
            public TestData()
                : base(new List<Person>()
                { 
                    new Student { Name = "Arnold" },
                    new Employee { Name = "Don", Salary = 100000.0f }
                }) { }
        }
    }
