    public class RouteViewModel : INotifyPropertyChanged
    {
        private Route _route; // My actual database model.
        public string Name
        {
            get { return _route.RouteName; }
        }
        public RouteViewModel(Route route)
        {
            _route = route;
        }
    }
