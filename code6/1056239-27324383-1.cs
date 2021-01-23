     public partial class Page1 : Page,INotifyPropertyChanged
    {
        private ObservableCollection<Person> _persons ;
        public ObservableCollection<Person> Persons
        {
            get
            {
                return _persons;
            }
            set
            {
                if (_persons == value)
                {
                    return;
                }
                _persons = value;
                 OnPropertyChanged();
            }
        }
    
        private Person _selectedPerson ;
        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                if (_selectedPerson == value)
                {
                    return;
                }
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }
        public Page1()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Person
    {
       public int PersonId { get; set; }
       public string PersonName { get; set; }
    }
