    static List<string> Usernames = new List<string>();
    public Form1()
    {
        InitializeComponent();
        Usernames.Add("Paul");
        Usernames.Add("Elaine");
        Usernames.Add("Elliot");
        Usernames.Add("Matt");
        Usernames.Add("Brian");
        BindingSource bs1 = new BindingSource();
        bs1.DataSource = Usernames;
        comboBox1.DataSource = bs1;
        BindingSource bs2 = new BindingSource();
        bs2.DataSource = Usernames;
        comboBox2.DataSource = bs2;
    }
