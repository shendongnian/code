	void sndPlayer_MediaOpened(object sender, EventArgs e)
	{
		// Set the current position in the recording
		sndPlayer.Position = currentRecording.tPosition;
		// Start playing
		sndPlayer.Play();
		// Schedule a function to stop the player
		timerControlPlayer.Interval = (double)currentDuration * 1000.0;
		timerControlPlayer.Start();
	}
	void timerControlPlayer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
	{
		// We don't need the timer to pop in again
		timerControlPlayer.Stop();
		// Access the gui thread (the sound player belongs to that one)
		guiDispatcher.Invoke(() =>
			{
				sndPlayer.Stop();
				SoundPlayed(this, new SoundPlayedEventArgs(currentRecording.nSpeakerCount));
				sndPlayer.Close();
			});
	}
	// Used as an elegant solution to start / stop the sound player
	timerControlPlayer = new System.Timers.Timer();
	timerControlPlayer.Elapsed += timerControlPlayer_Elapsed;
