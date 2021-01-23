    public class PushpinItem
    {
        public GeoCoordinate Location { get; set; }
        public string Text { get; set; }
    }
    public class MapPageViewModel : ReactiveObject
    {
        public ObservableCollection<PushpinItem> PushpinItems { get; set; }
        ...
        public MapPageViewModel()
        {
            PushpinItems = new ObservableCollection<PushpinItem>();
            setButton = new ReactiveAsyncCommand();
            setButton.Subscribe(x =>
            {
                PushpinItems.Add(new PushpinItem
                {
                    Location = new GeoCoordinate(...),
                    Text = ...
                });
            });
        }
    }
