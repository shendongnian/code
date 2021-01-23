    public class XamlLoadedType:UserControl, IComponentConnector
    {
        private bool _contentLoaded; 
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            var resourceLocater = new System.Uri(_uri, System.UriKind.Relative);            
            Application.LoadComponent(this, resourceLocater);
        }
        void IComponentConnector.Connect(int connectionId, object target) {
            this._contentLoaded = true;
        }
        string _uri ;
        public XamlLoadedType(string uri)
        {
            _uri = uri;
            InitializeComponent();
        }	
    }
