     <StackPanel>
        <DataGrid ItemsSource="{Binding PersonsViews}" AutoGenerateColumns="False" >            
            <DataGrid.Columns>
                <DataGridTextColumn Header="Age" Binding="{Binding Age}"/>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>                
            </DataGrid.Columns>
        </DataGrid>
        <DataGrid ItemsSource="{Binding PersonsFileterViews}" AutoGenerateColumns="False" >
            <DataGrid.Columns>
                <DataGridTextColumn Header="Age" Binding="{Binding Age}"/>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
            </DataGrid.Columns>
        </DataGrid>       
    </StackPanel>
    class MainViewModel
    {
        private ObservableCollection<Person> perList = new ObservableCollection<Person>();
        public ObservableCollection<Person> PersonList 
        {
            get { return perList; }
            set { perList = value; }
        }
        public ICollectionView PersonsViews { get; set; }
        public ICollectionView PersonsFileterViews { get; set; }
               
        public MainViewModel()
        {
            perList.Add(new Person() { Age = 1, Name = "Test1"});
            perList.Add(new Person() { Age = 2, Name = "Test2" });
            perList.Add(new Person() { Age = 3, Name = "Test3" });
            perList.Add(new Person() { Age = 4, Name = "Test4" });
            PersonsViews = new CollectionViewSource { Source = PersonList }.View;
            PersonsFileterViews = new CollectionViewSource { Source = PersonList }.View;
            PersonsFileterViews.Filter = new Predicate<object>(x => ((Person)x).Age > 2);            
        }     
    }
   
    public class Person
    {
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
       
    }
