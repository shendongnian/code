    public sealed class MyViewModel
    {
      public ObservableCollection<CommpleteStation> CommpleteStations{get;private set;}
      public MyViewModel()
      {
        CommpleteStations = new ObservableCollection<CommpleteStation>();
        CommpleteStations.Add(new CommpleteStation{Station="One", Distance="15",Price="130"};
      }
    }
