    public class ViewModel
    {
        private Collection<GeoGraphixModule> _geoGraphixModules;
        public ViewModel()
        {
            _geoGraphixModules = new Collection<GeoGraphixModule>();
            _geoGraphixModules.Add(new GeoGraphixModule(){Children = new Collection<Bla>(){new Bla{Children = new Collection<Bla>{new Bla(), new Bla(), new Bla()}}}});
            _geoGraphixModules.Add(new GeoGraphixModule(){Children = new Collection<Bla>(){new Bla{Children = new Collection<Bla>{new Bla(), new Bla(), new Bla()}}}});
            _geoGraphixModules.Add(new GeoGraphixModule(){Children = new Collection<Bla>(){new Bla{Children = new Collection<Bla>{new Bla(), new Bla(), new Bla()}}}});
            _geoGraphixModules.Add(new GeoGraphixModule(){Children = new Collection<Bla>(){new Bla{Children = new Collection<Bla>{new Bla(), new Bla(), new Bla()}}}});
        }
        public Collection<GeoGraphixModule> GeoGraphixModules
        {
            get { return _geoGraphixModules; }
            set { _geoGraphixModules = value; }
        }
    }
    public class GeoGraphixModule
    {
        public Brush ForegroundColor
        {
            get
            {
                if (SomeCheck())
                    return Brushes.Green;
                return Brushes.Red;
            }
        }
        private bool SomeCheck()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if ((randomNumber % 2) == 0)
                return true;
            return false;
        }
        private Collection<Bla> _children;
        public Collection<Bla> Children { get; set; }
    }
    public class Bla
    {
        private bool? _isChecked;
        private string _title;
        private Collection<Bla> _children;
        public bool? IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
            }
        }
        public Collection<Bla> Children
        {
            get { return _children; }
            set { _children = value; }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }
    }
