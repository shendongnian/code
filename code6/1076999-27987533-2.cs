    public class SomeContext : INotifyPropertyChanged
    {
        public ObservableCollection<Person> People { get; set; }
        public SomeContext()
        {
            People = new ObservableCollection<Person>();
            People.Add(new Person { Name = "Samuel" });
        }
        public void AddPerson()
        {
            People.Add(new Person { Name = "Peter" });
            OnPropertyChanged("People");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
