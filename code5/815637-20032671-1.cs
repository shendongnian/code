    public class Station
    {
      private string _stationName;
      public string Name
      {
         get { return _stationName; }
         set { _stationName = value; }
      }
      public Station(string station)
      {
         this.Name = station;
      }
    }
    public partial class MainPage : PhoneApplicationPage
    {
      ObservableCollection<Station> trainStations = new ObservableCollection<Station>();
      public MainPage()
      {
         InitializeComponent();
         myLLS.ItemsSource = trainStations;
         trainStations.Add(new Station("Germany"));
         trainStations.Add(new Station("France"));
         trainStations.Add(new Station("Italy"));
      }
    }
