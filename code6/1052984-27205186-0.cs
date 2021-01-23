    public class Probna1 : INotifyPropertyChanged
    {
        Person person;
        public Probna1()
        {
            person = new Person();
            person.FirstName = "Joseph";
            person.LastName = "Samuel";
            FirstNameTextBox.DataContext = person;
        }
    }
