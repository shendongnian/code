        [Table("Employee")]
        public partial class Employee : INotifyPropertyChanged
        {
            public Employee()
            {
                Projects = new ICollection<Project>();
            }
            private int _empId;
            public int EmpId 
            {
                get
                {
                    return _empId;
                }
                set
                {
                    _empId = value;
                    NotifyPropertyChanged("EmpId");
                }
            }
            private string _firstName;
            [StringLength(50)]
            public string FirstName
            {
                get
                {
                    return _firstName;
                }
                set
                {
                    _firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
