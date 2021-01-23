    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Person> NamesList  { get; private set; }
    
        public MainPage(){
            this.InitializeComponent();
            Person p = new Person();
            Person p2 = new Person();
    
            p.Name = "Piet";
            p.Gender = "Male";
            p2.Name = "Pietin";
            p2.Gender = "Female";
    
            NamesList = new ObservableCollection<Person>();
            NamesList.Add(p);
            NamesList.Add(p2); 
        }
