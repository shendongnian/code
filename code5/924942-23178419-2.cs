    public partial class DataGridComboBox : Window
    {
        public List<Fruits> Fruits { get; set; }
        public List<string> Result{ get; set; }
    
        public DataGridComboBox()
        {
            Fruits  = new List<Employee>()
            {
                new Employee() { Name = "Apple", Result= "Yes" },
                new Employee() { Name = "Mango",Result = "No" },
                new Employee() { Name = "Banana",Result ="MayBe" }
            };
    
            Result= new List<string>();
            Result.Add("Yes");
            Result.Add("No");
            Result.Add("MayBe");
            InitializeComponent();
            myGrid.ItemsSource = Fruits;
            Result.ItemsSource = Result;
        }
    
     
    }
