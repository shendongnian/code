        public Form1()
        {
            InitializeComponent();
            List<Country> countries = new List<Country>() { 
                new Country() { countryName = "Mattopia" , gdp = 1500, inflation = 1.5, f="hi"}, 
                new Country { countryName = "coffeebandit", gdp = 2000, inflation = 1.2, f="hey" }};
            listBox1.DisplayMember = "countryName";
            listBox1.DataSource = countries;
        }
        public class Country
        {
            public string countryName { get; set; }
            public double gdp { get; set; }
            public double inflation { get; set; }
            public double tradeBalance { get; set; }
            public int hdiRanking { get; set; }
            public LinkedList<string> tradePartners { get; set; }
            public string f;
        }
