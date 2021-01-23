	readonly Stopwatch _manipulationTimer = new Stopwatch();
	
	public void OnManipulationStarted(ManipulationStartedEventArgs e)
	{
		_manipulationTimer.Restart();
	}
	
	public void OnManipulationCompleted(ManipulationCompletedEventArgs e)
	{
		var millis = _manipulationTimer.ElapsedMilliseconds;
		if (Math.Abs(e.Cumulative.Translation.Y) < MaxVerticalSwipeDistanceInPix &&
			Math.Abs(e.Cumulative.Translation.X) > MinHorizontalSwipeDistanceInPix && 
			millis > MinSwipeDurationInMillis && 
			millis < MaxSwipeDurationInMillis && 
			Math.Abs(e.Cumulative.Scale - 1) < 0.01 // 1 touch point 
			)
		{ 
			var leftSwipe = e.Cumulative.Translation.X < 0;
			if (leftSwipe)
			{
			}
			else // right swipe
			{  				
			}
		}
		_manipulationTimer.Stop();
		_manipulationTimer.Reset();
	}
