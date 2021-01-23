    private void reverseButton_Click(object sender, RoutedEventArgs e)
	{
		Storyboard sbActive = bRotateClockwisely ? clockwiseStoryboard : counterClockwiseStoryboard;
		Storyboard sbPaused = bRotateClockwisely ? counterClockwiseStoryboard : clockwiseStoryboard;
		//I want the other storyboard can seek to where the animation is paused.
		dProgress = sbActive.GetCurrentProgress();
		dProgress = 1.0 - dProgress;
		sbActive.Stop();           
		sbPaused.Begin();
		sbPaused.Seek(new TimeSpan((long)(duration.Ticks * dProgress)), TimeSeekOrigin.BeginTime);
		bRotateClockwisely = !bRotateClockwisely;            
	}
