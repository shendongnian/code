    private bool _ImageOneSet;
    
    public MainWindow()
    {
    	InitializeComponent();
    	_ImageOneSet = false;
    }
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		if (!_ImageOneSet)
		{
			// set image one
            _ImageOneSet = true;
		}
		else
		{
			// set image two
		}		
	}
