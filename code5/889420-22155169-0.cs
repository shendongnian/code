    void cIconImage_Loaded(object sender, RoutedEventArgs e)
    {
    	var thread = new System.Threading.Thread(() =>
    	{
    		CoInitialize((IntPtr)0);
    		var source = GetImage(mypath);
    		this.Dispatcher.BeginInvoke(new Action(() =>
    		{
    				this.Source = source;
    		}), System.Windows.Threading.DispatcherPriority.Background);
    		CoUninitialize();
    	});
    	thread.IsBackground = true;
    	thread.SetApartmentState(System.Threading.ApartmentState.STA);
    	thread.Start();
    }
