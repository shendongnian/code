    myProgBar.IsIndeterminate = true;
    
    
    Thread t = new Thread(new ThreadStart(() => 
    {
    while (true) {//do work}
    myProgBar.Dispatcher.Invoke(new Action(() => { myProgBar.Visibility = Visibility.Hidden; }));
    }));
    
    myProgBar.Visibility = Visibility.Visible;
    t.Start();
    
   
