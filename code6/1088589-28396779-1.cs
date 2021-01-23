     public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new TestViewModel();
        }      
    }
    class TestViewModel
    {
        private ObservableCollection<Person> myVar;
        public ObservableCollection<Person> Persons
        {
            get { return myVar; }
            set { myVar = value; }
        }
        public DelegateCommand<Person> RemoveCustomer { get; set; }
        public TestViewModel()
        {
            Persons = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++)
            {
                Persons.Add(new Person() { FirstName = "Test"+i, LastName = "Testlst"+i });
            }
            RemoveCustomer = new DelegateCommand<Person>(Removeperson);
        }
        private void Removeperson(Person prps)
        {
        }
    }
    public class Person
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
 
