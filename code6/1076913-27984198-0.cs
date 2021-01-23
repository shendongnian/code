    public class MyMap : Map
    {
        public static readonly BindableProperty LocationsProperty = BindableProperty.Create<MyMap, List<string>>(x => x.Locations, new List<string>());
        public MyMap(List<string> locations)
        {
            Locations = locations;
        }
        public List<string> Locations
        {
            get { return (List<string>)GetValue(LocationsProperty); }
            set { SetValue(LocationsProperty, value); }
        }
    }
