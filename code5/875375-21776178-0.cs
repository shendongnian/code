    public class Recording 
    {
      public string Artist { get; set; }
      public string Name { get; set; }
      public DateTime ReleaseDate { get; set; }
    }
    public ObservableCollection<Recording> MyMusic = new ObservableCollection<Recording>();
    MyMusic.Add(new Recording("Chris Sells", "Chris Sells Live",
        new DateTime(2008, 2, 5)));
    MyMusic.Add(new Recording("Luka Abrus",
        "The Road to Redmond", new DateTime(2007, 4, 3)));
    MyMusic.Add(new Recording("Jim Hance",
        "The Best of Jim Hance", new DateTime(2007, 2, 6)));
    // Set the data context for the combo box.
    ComboBox1.DataContext = MyMusic;
