    var dispatcherTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
    int i=0;
    dispatcherTimer.Tick += (sender, args) => {
        if (i>0) 
            FlipBookImages[i-1].Visibility = Visibility.Collapsed;
        if (i>=FlipBookImages.Count) 
           dispatcherTimer.Stop();
        else 
           FlipBookImages[i].Visibility = Visibility.Visible;
        i++;
    };
    dispatcherTimer.Start();
   
    
