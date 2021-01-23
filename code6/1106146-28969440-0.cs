    <StackPanel>
        <ListView x:Name="_companies" ItemsSource="{Binding Companies}" >
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="ID" DisplayMemberBinding="{Binding ID}" />
                    <GridViewColumn Header="Company Name" DisplayMemberBinding="{Binding Name}" />
                </GridView>
            </ListView.View>
        </ListView>
        <ListView x:Name="_materials" ItemsSource="{Binding ElementName=_companies,Path=SelectedItem.MaterialList}" >
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="ID" DisplayMemberBinding="{Binding ID}"/>
                    <GridViewColumn  Header="Name" DisplayMemberBinding="{Binding Name}"/>
                </GridView>
            </ListView.View>
        </ListView>
        <TextBox x:Name="_description" Text="{Binding ElementName=_materials, Path=SelectedItem.Description}" IsReadOnly="True" />
    </StackPanel>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
      class MainViewModel 
    {      
        private ObservableCollection<Company> companies;
        public ObservableCollection<Company> Companies
        {
            get { return companies; }
            set { companies = value; }
        }        
        public MainViewModel()
        {
            companies = new ObservableCollection<Company>();
            for (int i = 0; i < 10; i++)
            {
                Company comp = new Company();
                comp.ID = i + 1;
                comp.Name = "Comp" + i;
                ObservableCollection<Material> matlist = new ObservableCollection<Material>();
                for (int j = 0; j < 10; j++)
                {
                    Material mat = new Material();
                    mat.ID = j + 1;
                    mat.Name = "Mat" + j + i;
                    mat.Description = "descrp" + j + i;
                    matlist.Add(mat);
                }
                comp.MaterialList = matlist;
                companies.Add(comp);
            }            
        }
    }
    class Company 
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;  }
        }
        private ObservableCollection<Material> materialList;
        public ObservableCollection<Material> MaterialList
        {
            get { return materialList; }
            set { materialList = value; }
        }       
    }
    class Material 
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
