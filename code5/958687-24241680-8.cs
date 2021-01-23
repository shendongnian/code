    ObservableCollection<Songs> SongsList=new ObservableCollection<SongsL();
    for (int j = 0; j <= 300; j++)
    {
       SongsList.Add(new Songs{Artist="Aritst Name",Name="Song Name"});
    }
    // Set this Collection from the codebehind or xaml .
    ListBox1.ItemSource=SongsList; // it will the bind the public properties in this Songs.
