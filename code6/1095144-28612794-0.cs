    <DataGrid  ItemsSource="{Binding Persons}" AutoGeneratingColumn="DataGrid_AutoGeneratingColumn"/>
     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "FirstName")
            {
                DataGridComboBoxColumn cboclm = new DataGridComboBoxColumn();
                cboclm.Header = "First Name";
                cboclm.ItemsSource = (DataContext as ViewModel).Names;
                cboclm.SelectedValueBinding = new Binding("FirstName");
                e.Column = cboclm;
            } 
        }
    }
     class ViewModel
    {
        private ObservableCollection<Person> persons = new ObservableCollection<Person>();
        public ObservableCollection<Person> Persons
        {
            get { return persons; }
            set { persons = value; }
        }
        private ObservableCollection<string> names = new ObservableCollection<string>();
        public ObservableCollection<string> Names
        {
            get { return names; }
            set { names = value; }
        }   
        public ViewModel()
        {
            Person p = new Person();
            persons.Add(p);
            Names.Add("Test1");
            Names.Add("Test2");
        }
        
    }
    class Person
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }       
    }
