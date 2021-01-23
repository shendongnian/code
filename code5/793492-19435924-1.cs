    System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
    dt.Interval = TimeSpan.FromSeconds(1); //or whatever interval you want
    dt.Tick += (s, e) =>
    { 
        rects[r.Next(0,3)].Fill = red;
    }
        
