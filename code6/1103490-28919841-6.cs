    public MainWindow()
    {
        _orderItem = new BindingList<OrderDetailsListItem>();
        _orderItem.ListChanged += OrderItemListChanged;
        InitializeComponent();
        GetBeerInfo();
        //You will see why all the the rest of the items were removed in the next part.
    }
    private void OrderItemListChanged(object sender, ListChangedEventArgs e)
    {
        TotalPrice = OrderItem.Select(x => x.Price).Sum();
    }
