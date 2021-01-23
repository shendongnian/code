    public Form1()
    {
        InitializeComponent();
        
        this.Load += Form1_Load;
        comboBoxCountry.SelectedIndexChanged += comboBoxCountry_SelectedIndexChanged;
    }
    private Dictionary<string, string[]> _countryList;
    public Dictionary<string, string[]> CountryList
    {
        get
        {
            if (_countryList == null)
            {
                _countryList = new Dictionary<string, string[]>();
                _countryList["Bulgaria"] = new string[] { "Sofia University St Kliment Ohridski", "Technical University of Sofia", "Plovdiv University Paisii Hilendarski" };
                _countryList["Romania"] = new string[] { "Alexandru Ioan Cuza University", "Babes-Bolyai University", "University of Bucharest" };
                _countryList["Serbia"] = new string[] { "University of Belgrade", "University of Novi Sad", "University of Niš" };
            }
            return _countryList;
        }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (var CountryKey in CountryList.Keys)
            comboBoxCountry.Items.Add(CountryKey);
        comboBoxCountry.SelectedIndex = 0;
    }
    private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedCountry = comboBoxCountry.SelectedItem.ToString();
        
        listBoxUniversities.Items.Clear();
        listBoxUniversities.Items.AddRange(CountryList[selectedCountry]);
    }
