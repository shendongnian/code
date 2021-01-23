    class SplitButtonItem
    {
    	public string Text { get; set; }
    }
    
    public MainWindow()
    {
    	InitializeComponent();
    
    	var button1 = new SplitButtonItem() { Text = "Item 01", };
    	var button2 = new SplitButtonItem() { Text = "Item 02", };
    	var buttonList = new List<SplitButtonItem>() 
    	{
    		button1, 
    		button2,
    	};
    	splitButton.ItemsSource = buttonList;
    }
        
