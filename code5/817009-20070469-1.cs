    public class MainWindow
    {
    SongsList songs;
    
    public MainWindow()
    {
        InitializeComponent();
        songs = new SongList();
        listBox.DataContext = songs;
    }
    
    public void Button_Click(object sender, EventArgs e)
    {
        songs = SongList.Load();
        Song newSong = Song.Load("AC/DC;Back In Black;Hells Bells");
        songs.Add(newSong);
        listbox.Items.Refresh();
    }
    
    }
