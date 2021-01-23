    int change = 1;
    
    DispatcherTimer timer = new DispatcherTimer();
    timer.Interval = TimeSpan.FromSeconds(2);
    timer.Tick += (o, a) =>
        {
            // If we'd go out of bounds then reverse
            int newIndex = flipView1.SelectedIndex + change;
            if (newIndex >= flipView1.Items.Count || newIndex < 0)
            {
                change *= -1;
            }
    
            flipView1.SelectedIndex += change;
        };
    
    timer.Start();
