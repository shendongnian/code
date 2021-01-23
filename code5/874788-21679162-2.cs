	public PersonCredential()
	{
        InitializeComponent();
        SCLib type = new SCLib();
        type.StartMonitoring();
        type.CardArrived += (string ATR) => { 
            // when card arrives, dispatch back to UI thread
        	Dispatcher.BeginInvoke(new Action(() => {
        		this.CardHolderName.Content = ATR; 
        	}));
    	};
	}
