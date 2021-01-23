     public SelectProfile()
            {
               
                InitializeComponent();
    
                ObservableCollection<Player> players = new ObservableCollection<Player>();
                players.Add(new Player { FirstName = "Waseem" });
                players.Add(new Player { FirstName = "Waseem2" });
                players.Add(new Player { FirstName = "Waseem3" });
                players.ItemsSource = players; // assigning data
            }
