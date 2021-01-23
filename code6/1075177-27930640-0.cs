    //Settings code:
    MediaMediator.UpdateVolume(10);
    
    //Mediator
    public static event Action<int> VolumeUpdated;
    
    public static void UpdateVolume(int level)
    {
        //Please do the handler/null check, not here for brevity
        UpdateVolume(level);
    }
    
    //ViewModel
    public int CurrentVolume {get; set;} //Actually using INotifyPropertyChanged of course
    MediaMediator.VolumeUpdated += (l => CurrentVolume = l);
    //View
    <MediaElement ... Volume="{Binding CurrentVolume}"/>
