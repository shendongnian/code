        public class MainViewModel : ViewModelBase
        {
    
            private readonly IDataService _dataService;
            private string _welcomeTitle = string.Empty;
            private ViewModelBase detailsViewModel = null;
            public ViewModelBase DetailsViewModel{
               get { return detailsViewModel;}
               set { detailsViewModel = value; RaisePropertyChanged("DetailsViewModel"); }
            }
            /// <summary>
            ///     Initializes a new instance of the MainViewModel class.
            /// </summary>
            public MainViewModel(IDataService dataService)
            {
                _dataService = dataService;
                _dataService.GetData(
                    (item, error) =>
                    {
                       detailsViewModel = new ServerViewModel(item); //ViewModel for the ServerView
                    });
            }
        }
    <igWpf:XamRibbonWindow.Resources>
        <DataTemplate DataType="{x:Type viewModel:ServerViewModel}">
           <views:ServerView />
        </DataTemplate>
    </igWpf:XamRibbonWindow.Resources>
    <ContentPresenter Content="{Binding DetailsViewModel}" Grid.Column="1"/>
    
