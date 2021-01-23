    ...
    public MainWindow()
    {
    	InitializeComponent();
    
    	List<InvoiceItem> _source = new List<InvoiceItem>
    	{
    		new InvoiceItem
    		{
    		  ItemName = "Item1",
    		  Options = new List<InvoiceOption>
    		  {
    			  new InvoiceOption { OptionName = "Option1" },
    			  new InvoiceOption { OptionName = "Option2" }
    		  }
    		},
    		new InvoiceItem
    		{
    		  ItemName = "Item2",
    		  Options = new List<InvoiceOption>
    		  {
    			  new InvoiceOption { OptionName = "Option3" },
    			  new InvoiceOption { OptionName = "Option4" }
    		  }
    		}
    	};
    
    	this.DataContext = _source;
    }
    ...
