    public void Initialize()
        {
            // Register media elements to the Sound Service.
            try
            {
                DependencyObject rootGrid = VisualTreeHelper.GetChild(Window.Current.Content, 0);
                var foregroundPlayer = (MediaElement)VisualTreeHelper.GetChild(rootGrid, 0) as MediaElement;
                var backgroundPlayer = (MediaElement)VisualTreeHelper.GetChild(rootGrid, 1) as MediaElement;
                SoundPlayer.ForegroundPlayer = foregroundPlayer;
                // Keep the state.
                var isMuted = this.IsBackgroundMuted;
                SoundPlayer.BackgroundPlayer = backgroundPlayer;
                this.IsBackgroundMuted = isMuted;
            }
            catch (Exception)
            {
                // Most probably you forgot to apply the custom root frame style.
                SoundPlayer.ForegroundPlayer = null;
                SoundPlayer.BackgroundPlayer = null;
            }
        }
        public async Task Play(string soundPath, bool inBackground = false)
        {
            var mediaElement = inBackground ? BackgroundPlayer : ForegroundPlayer;
            if (mediaElement == null)
            {
                return;
            }
            mediaElement.Source = new Uri(soundPath);
            await mediaElement.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                mediaElement.Stop();
                mediaElement.Play();
            });
        }
  
