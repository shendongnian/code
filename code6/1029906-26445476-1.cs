    this.MyMarket = new Market
    {
        Name = "My Market",
        Products = new ObservableCollection<Product>
        {
            new Product { Id = 123, Description = "qwerty" },
            new Product { Id = 234, Description = "wertyu" }
        }
    };
    this.InitializeComponent();
    this.NavigationCacheMode = NavigationCacheMode.Required;
