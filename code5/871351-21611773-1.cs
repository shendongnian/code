    public class DomainViewModel
    {
        public ReadOnlyCollection<RouteViewModel> Routes { get; set; }
        public ReadOnlyCollection<SkyViewModel> SkyLines { get; set; }
        public DomainViewModel(List<Route> routes)
        {
            Routes = new ReadOnlyCollection<RouteViewModel>(
                (from route in routes
                 select new RouteViewModel(route))
                 .ToList<RouteViewModel>());
        }
            Skylines = new ReadOnlyCollection<SkyViewModel>(
                (from route in routes
                 select new SkyViewModel(route))
                 .ToList<SkyViewModel>());
        }
    }
