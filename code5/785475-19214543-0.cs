    if (_wasEdited)
    {
       DispatcherTimer t = new DispatcherTimer(DispatcherPriority.Normal, Dispatcher);
       t.Tick += new EventHandler((o,e) => 
         ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
       t.Interval = TimeSpan.FromMilliseconds(1000);
       t.Start();
    }
