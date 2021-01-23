    Point start;
    
    void ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e) {
    	start = e.Position;
    }
    
    void ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e) {
    	if (e.IsInertial) {
    		if (start.X - e.Position.X > 500) //swipe left
    		{
    			e.Complete();
    		}
    	}
    }
