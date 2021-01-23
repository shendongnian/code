    public ObservableCollection<Song> Songs {get;set;}
    public Song SelectedSong {get;set;}
    
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        ...
        Songs = response.Musics;
    }
