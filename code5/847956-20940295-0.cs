    public Form1()
    {
        InitializeComponent();
        List<Team> teams = new List<Team>(5500);
       
        for (int y = 1; y < 5501; y++)
        {
            teams.Add(new Team(y));
        }
    }
