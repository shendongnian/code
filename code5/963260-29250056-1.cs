    public class MainViewModel : Screen
    {
        public MainViewModel()
        {
            DisplayName = "DevExpress Test Environment";
        }
        private static BindableCollection<Screen> _tbCtrl = new BindableCollection<Screen>();
        public BindableCollection<Screen> TbCtrl
        {
            get { return _tbCtrl; }
            set
            {
                _tbCtrl = value;
                NotifyOfPropertyChange(() => TbCtrl);
            }
        }
    }
