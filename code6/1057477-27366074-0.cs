    public class MediaPlayer {
        public event EventHandler<Track> OnTrackComplete;
        private Dispatcher { get; set; }
        public MediaPlayer(Dispatcher guiDispatcher){
            // Other code ...
            if(guiDispatcher == null) 
                throw new ArgumentNullException("guiDispatcher", "Cannot properly initialize media player, since no callback can be fired on GUI thread.");
            Dispatcher = guiDispatcher;
        }
        public void Play() {
            // Fire immediately on thread calling 'Play', since we'll forward exec. on gui thread anyway.
            FireOnTrackComplete(); 
        }
        protected virtual void FireOnTrackComplete()
        {
            // Pretending "loadedTrack" was set somewhere before.
            Dispatcher.Invoke(() => {
                if (OnTrackComplete != null)
                    OnTrackComplete(this, loadedTrack);
            });
        }
    }
    // Somewhere in your initialization code
    // ...
    MediaPlayer player = new MediaPlayer(App.Current.Dispatcher); // If you use WPF. Don't know if this applies to WinForms too.
    // ...
