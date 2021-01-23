	public PersonCredential()
	{
		InitializeComponent();
		// monitor on another thread
		new Thread(() => {
	        SCLib type = new SCLib();
	        type.StartMonitoring();
	        // when card arrives, dispatch back to UI thread
	        type.CardArrived += (string ATR) => { 
	        	Dispatcher.BeginInvoke(new Action(() => {
	        		this.CardHolderName.Content = ATR; 
	        	}));
        	};
		}).Start();
	}
