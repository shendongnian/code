    foreach(string svgFile in listOfSVGsInFolder)
    {
        Task.Run(() =>
          {
    		Debug.WriteLine ("Creating SVG in thread {0}", Thread.CurrentThread.ManagedThreadId);
    
    		Icon icon = // whatever you do to create it
    
    		Dispatcher.Invoke(new Action(() =>
    		  {         
    		     WrapPanel.Children.Add(icon);
    		  }));
          });
    }
