    public partial class MainWindow : Window, INotifyPropertyChanged
    {
    	private PriceModel _selectedPair;
    
    	public MainWindow()
    	{
    		InitializeComponent();
    		DataContext = this;
    
    		MarketPrices = new ObservableCollection<PriceModel>
    		{
    			new PriceModel("GBPUSD") {AskPrice = 1.60345, OfferPrice = 1.60335, },
    			new PriceModel("GBPEUR") {AskPrice = 1.71345, OfferPrice = 1.71335, },
    			new PriceModel("USDGBP") {AskPrice = 1.23345, OfferPrice = 1.23335, },
    			new PriceModel("GBPJPY") {AskPrice = 1.34345, OfferPrice = 1.34335, }
    		};
    	}
    
    	public ObservableCollection<PriceModel> MarketPrices { get; set; }
    
    	public PriceModel SelectedPair
    	{
    		get { return _selectedPair; }
    		set
    		{
    			_selectedPair = value;
    			OnPropertyChanged("SelectedPair");
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
