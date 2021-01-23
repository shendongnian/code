    public class MainViewModel : ViewModelBase {
        private INavigationService _navigationService;
        public RelayCommand<Tuple<string, string>> DetailsCommand { get; set; }
     
        public MainViewModel(INavigationService navigationService) {
            this._navigationService = navigationService;
            DetailsCommand = new RelayCommand<Tuple<string, string>>((args) => NavigateTo(args));
        }
    
        public void NavigateTo(Tuple<string, string> args) {
            this._navigationService.NavigateTo(args.Item1, args.Item1);
        }
    
        public void ClickAndNavigate() {
            NavigateTo(new Tuple<string, string>("AdminPivotPage", "Test Params"));
        }
    }
