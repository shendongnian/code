    public class MainViewModel:INotifyPropertyChanged
    {
        public ICommand LoadCommand { get; set; }
        object _loadedContent;
        public object LoadedContent
        {
            get { return _loadedContent; }
            set {
                SetField(ref _loadedContent, value, "LoadedContent");
            }
 
        }
        public MainViewModel()
        {
            LoadCommand = new RelayCommand(Load, ()=>true);
        }
        private void Load()
        {
            var xamlLoaded = new XamlLoadedType("/WPFApplication1;component/XamlToLoad.xml.xaml");
            xamlLoaded.DataContext = new { Label = "HeyDude" };
            LoadedContent = xamlLoaded;
            
        }
    }
