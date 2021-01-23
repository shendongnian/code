    // View constructor
    public HubView()
    {  
      this.InitializeComponent();
      this.WhenActivated(d =>
      {
        // ViewModel is a property of this view
        d(this.OneWayBind(ViewModel, x => x.MyListWithData, x => x.YourCVS.Source));
      });
    }
