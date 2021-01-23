    namespace XXXX
    {
    	public partial class VideoWindow :  Window
    	{
    
    		private DispatcherTimer mediaPositionTimer;  // We check the play position of the video each time this fires to see if it has hung
    		double _lastPosition = -1;
    		int _video_count;
    		int videoDuration;  
            DateTime lastVideoStartTime;
    
    		public VideoWindow()
    		{
    			adMediaElement.LoadedBehavior = MediaState.Manual;
    
                adMediaElement.MediaEnded  += adMediaElement_MediaEnded;
                adMediaElement.MediaOpened += adMediaElement_MediaOpened;
                adMediaElement.MediaFailed += adMediaElement_MediaFailed;
    
    		}
    
            // Increment the counter every time we open a video
            void adMediaElement_MediaOpened(object sender, RoutedEventArgs e)
            {
                Log("Media opened");
                _video_count++;
            }
    
    		// If we have a failure then just start the next video
            void adMediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
            {
                Log("Media failed");
                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                {
                    PlayNextMedia();
                }));
            }
    
       		// When a video ends start the next one
            private void adMediaElement_MediaEnded(object sender, RoutedEventArgs e)
            {
               Log("MediaEnded called");
    			this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                {
                	PlayNextMedia();
    			}));
            }
    		
    		// Stops and Closes any existing video
    		// Increments the file pointer index
    		// Switches to display ads if no more videos
    		// else
    		// Starts the video playing
            private void PlayNextMedia()
            {
               // Log(String.Format("PlayNextMedia called"));
    
                //Close the existing file and stop the timer
                EndVideo2();
                adMediaElement.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                    {
                        adMediaElement.Stop();
                        adMediaElement.Close();
                    }));
    
                currentMediaFileIndex++;
    
                if (currentMediaFileIndex > (mediaFileCount - 1))
                {
                    Log(String.Format("  switching to Ads, currentMediaFileIndex = {0}", currentMediaFileIndex));
                    // Now setup and then run static adds for 10 minutes
                    currentMediaFileIndex = 0;
                    StartAds();
    
                }
                else
                {
                    Log(String.Format("  switching media, index = {0}", currentMediaFileIndex));
                    adMediaElement.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                    {
                        StartVideo2();
                    }));
                }
            }
    
    		// Stops the mediaPositionTimer, must be called in conjunction with a admediaElement.Pause() or Stop()
            private void EndVideo2()
            {
               // Log("EndVideo2() called");
                _is_playing = false;
                // Stop the timer
                if (mediaPositionTimer != null)
                {
                    mediaPositionTimer.Stop();
                }
            }
    
    		// Load the media file
    		// Set the volume
    		// Set the lastVideoStartTime variable
            private void StartVideo2()
            {
               // Log("StartVideo2() called");
                loadMediaFile(currentMediaFileIndex);
    
                adMediaElement.Volume = Properties.StationSettings.Default.VolumeMedia;
                lastVideoStartTime = DateTime.Now;  // Record the time we started
                
                // Stop the timer if it exists, otherwise create a new one
                if (mediaPositionTimer == null)
                {
                    mediaPositionTimer = new DispatcherTimer();
                    // Set up the timer     
                    mediaPositionTimer.Interval = TimeSpan.FromSeconds(10);
                    mediaPositionTimer.Tick += new EventHandler(positionTimerTick);
                }
                else
                {
                    mediaPositionTimer.Stop();
                }
                // Start it running
                adMediaElement.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                    {
                        mediaPositionTimer.Start();
                        _is_playing = true;
                        adMediaElement.Play();
                    }));
            }
    
    
            private void RestartVideo2()
            {
                //Log("Restart the video");
                adMediaElement.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                    {
                        mediaPositionTimer.Start();
                        _is_playing = true;
                        adMediaElement.Play();
                    }));
            }
    
    		// Check the playback position of the mediaElement has moved since the last check, 
    		//  if not then the video has hung
    		// Also check if the playback position exceeds the video duration,
    		//  if so it has also hung
    		// If video has hung then force the next one to start and report a Warning
            private void positionTimerTick(object sender, EventArgs e)
            {
                double duration;
                double currentPosition = adMediaElement.Position.TotalSeconds;
    
                if (adMediaElement.NaturalDuration.HasTimeSpan)
                {
                    duration = adMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                }
                else
                {
                    duration = 5 * 60; // Default to 5 minutes if video does not report a duration
                }
    
                if ((currentPosition == lastPosition) || currentPosition > (duration + 30))
                {
                    // do something
                    //Log("*** Video position has exceed the end of the media or video playback position has not moved ***");
    
                    if (_is_playing)
                    {
                        String logString = String.Format("*** Video {0} has frozen ({1}c:{2}l:{3}d)so forcing the next one to start ***", mediaFiles[currentMediaFileIndex], currentPosition, lastPosition, duration);
                        Log(logString);
    
                        PlayNextMedia();
    
                        // Send a message indicating we had to do this
                        mainWindow.SendHeartbeat(MainWindow.STATUS_WARNING, logString);
    
                    }
                }
                lastPosition = currentPosition;
            }
    
    	}
    }
