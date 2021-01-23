    <Grid x:Name="LayoutRoot">
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
    
        <TextBox x:Name="txtSearch" Grid.Row="0" FontSize="14" Margin="10, 0, 10, 0" Height="28" Width="74"
                 Text="{Binding Path=SearchString, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
        
        <DataGrid Grid.Row="1" AutoGenerateColumns="True" ItemsSource="{Binding FilteredClients, Mode=TwoWay}" SelectedItem="{Binding SelectedClient}" />
    </Grid>
        public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IDataService dataService)
        {
            allClients = new List<Client>();
            filteredClients = new List<Client>();
            GetAll();
        }
        public const string SearchStringPropertyName = "SearchString";
        private string searchString = string.Empty;
        public string SearchString
        {
            get
            {
                return searchString;
            }
            set
            {
                if (searchString == value)
                {
                    return;
                }
                searchString = value;
                if (searchString == string.Empty)
                {
                    filteredClients = allClients;
                }
                else
                {
                    FilterAll();
                }
                RaisePropertyChanged(FilteredClientsPropertyName);
                RaisePropertyChanged(SearchStringPropertyName);
            }
        }
        public const string AllClientsPropertyName = "AllClients";
        private List<Client> allClients;
        public List<Client> AllClients
        {
            get
            {
                return allClients;
            }
            set
            {
                if (allClients == value)
                {
                    return;
                }
                RaisePropertyChanging(AllClientsPropertyName);
                allClients = value;
                RaisePropertyChanged(AllClientsPropertyName);
            }
        }
        public const string FilteredClientsPropertyName = "FilteredClients";
        private List<Client> filteredClients;
        public List<Client> FilteredClients
        {
            get
            {
                return filteredClients;
            }
            set
            {
                if (filteredClients == value)
                {
                    return;
                }
                RaisePropertyChanging(FilteredClientsPropertyName);
                filteredClients = value;
                RaisePropertyChanged(FilteredClientsPropertyName);
            }
        }
        public const string SelectedClientPropertyName = "SelectedClient";
        private Client selectedClient;
        public Client SelectedClient
        {
            get
            {
                return selectedClient;
            }
            set
            {
                if (selectedClient == value)
                {
                    return;
                }
                RaisePropertyChanging(SelectedClientPropertyName);
                selectedClient = value;
                RaisePropertyChanged(SelectedClientPropertyName);
            }
        }
        private void GetAll()
        {
            AddClient("sally", "may", 10000);
            AddClient("bert", "benning", 10000);
            AddClient("ernie", "manning", 10000);
            AddClient("lisa", "ann", 10000);
            AddClient("michael", "douglas", 10000);
            AddClient("charlie", "sheen", 10000);
            filteredClients = allClients;
        }
        private void AddClient(String firstname, String lastname, Double salary)
        {
            Client clientadd = new Client();
            clientadd.FirstName = firstname;
            clientadd.LastName = lastname;
            clientadd.Salary = salary;
            allClients.Add(clientadd);
        }
        private void FilterAll()
        {
            filteredClients = (from c in allClients where c.FullName.Contains(searchString) orderby c.FullName select c).ToList();
        }
    }
    public class Client
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Double Salary { get; set; }
        public String FullName { get { return LastName + ", " + FirstName; } }
    
        public List<Client> Clients { get; set; }
    
    }
