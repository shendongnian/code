        dispatcherTimer1 = new DispatcherTimer();
        int timeSlider = (int)(11 - theSlider.Value);
        MessageBox.Show(""+timeSlider);
        dispatcherTimer1.Interval = TimeSpan.FromSeconds(timeSlider);
        dispatcherTimer1.Tick += delegate
