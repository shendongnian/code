            InitializeComponent();
            ROMS.Insert(0, new Rom());
            ROMS.Insert(1, new Rom());
            ROMS[0].Name = "Congo Bongo";
            ROMS[0].Game.Art.Screen.Source = new BitmapImage(new Uri(@"E:\Arcade\Art\Box\Intellivision\Congo Bongo.jpg", UriKind.Absolute));
            ROMS[0].Game.Date = "1983";
            ROMS[0].Game.Platform = "Intellivision";
            ROMS[1].Name = "Donkey Kong";
            ROMS[1].Game.Art.Screen.Source = new BitmapImage(new Uri(@"E:\Arcade\Art\Box\Intellivision\Donkey Kong.jpg", UriKind.Absolute));
            ROMS[1].Game.Date = "1982";
            ROMS[1].Game.Platform = "Intellivision";
 
            ROM_list.ItemsSource = ROMS;
