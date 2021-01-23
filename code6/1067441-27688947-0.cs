    // this is the timer
    timerVideoTime = new DispatcherTimer();
                timerVideoTime.Interval = TimeSpan.FromSeconds(1);
                timerVideoTime.Tick += new EventHandler(timer_Tick);
                timerVideoTime.Start();
            }
    
    // the actual timer handler.
    void timer_Tick(object sender, EventArgs e)
            {
                // Check if the movie finished calculate it's total time
                if (MyMediaElement.NaturalDuration.TimeSpan.TotalSeconds > 0)
                {
                    if (TotalTime.TotalSeconds > 0)
                    {
                        var sliderValue = MyMediaElement.Position.TotalSeconds /
                                           TotalTime.TotalSeconds;
    
                        if(Slider.Value != sliderValue){
                          Slider.SetCurrentValue(Slider.ValueProperty, sliderValue); 
                        }
                    }
                }
