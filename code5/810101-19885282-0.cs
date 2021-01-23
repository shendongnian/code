    public class LocationEntryViewModel : BaseViewModel
    {
      public INotifyTaskCompletion<GeoCoordinate> MyLocation { get; private set; }
      public LocationEntryViewModel()
      {
        MyLocation = NotifyTaskCompletion.Create(GetMyLocation());
      }
    }
