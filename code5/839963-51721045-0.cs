    private void btnFoo_Click(object s, RoutedEventArgs e)
    {
    	var btn = (Button)sender;
	    btn.IsEnabled = false; //Disable button.
    	var fooTimer = new System.Timers.Timer(5000); //Exceute after 5000 milliseconds
	    timer.Elapsed += (fooTimer_s, fooTimer_e) => 
    	{
            //It has to be dispatched because of thread crossing if you are using WPF.
	    	Dispatcher.Invoke(()=>  
    		{
    			btn.IsEnabled = true; //Bring button back to life by enabling it.
    			fooTimer.Dispose();
    		});
    	};
    	fooTimer.Start();
    	//Insert your code here :)
    }
