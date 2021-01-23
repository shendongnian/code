    private List<Country> value = new List<Country>();
        public MainWindow()
        {
            InitializeComponent();
            this.Values.Add(new Country{ Name = "America"});
            this.Values.Add(new Country{Name = "Africa"});
            this.Values.Add(new Country{Name = "India"});
        }
        public List<Country> Values
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
    public class Country
    {
        public string Name { get; set; }
    }
