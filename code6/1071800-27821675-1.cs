    foreach(string svgFile in listOfSVGsInFolder)
    {
        Task.Run(() =>
          {
    		Debug.WriteLine ("Creating SVG in thread {0}", Thread.CurrentThread.ManagedThreadId);
    
    		Icon icon = // whatever you do to create it
    
    		Application.Current.Dispatcher.BeginInvoke(
              DispatcherPriority.Background,
              () => {         
                      WrapPanel.Children.Add(icon);
                    });
          });
    }
