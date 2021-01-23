    internal class SongPlayerViewModel : INotifyPropertyChanged
    {
    public event PropertyChangedEventHandler PropertyChanged;
    private Song _songPlaying;
    public Song SongPlaying
    {
      get { return _songPlaying; }
      set { 
        _songPlaying = value;
        OnPropertyChanged("SongPlaying");
      }
    }
    
    protected void OnPropertyChanged(string name)
    {
      var handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(name));
      }
    }
