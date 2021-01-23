    public class ViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }
        public ViewModel()
        {
            Persons = new ObservableCollection<Person>();
        }
    }
