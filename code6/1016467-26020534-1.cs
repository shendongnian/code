    public class Database
    {
        public string Name { get; set; }
    
        public IList<Company> Companies;
    
        public Database()
        {
            Companies = new List<Company>();
        }
    }
    
    public class Company
    {
        public string Name { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var databases = new List<Database>
            {
                new Database
                {
                    Name = "Database 1 Name",
                    Companies = new List<Company>
                    {
                        new Company {Name = "123"},
                        new Company {Name = "Abc"}
                    }
                },
                new Database
                {
                    Name = "Database 2 Name",
                    Companies = new List<Company> {new Company {Name = "Xyz"}}
                },
                new Database
                {
                    Name = "Database 3 Name",
                    Companies = new List<Company> {new Company {Name = "Test"}}
                },
            };
    
            DatabaseListView.DataSource = databases;
            DatabaseListView.DataBind();
        }
    }
    
    protected void DatabaseListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var database = e.Item.DataItem as Database;
            var companyListView = e.Item.FindControl("CompanyListView") as ListView;
    
            companyListView.DataSource = database.Companies;
            companyListView.DataBind();
        }
    }
