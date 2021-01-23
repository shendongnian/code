    public class MediaPlayer {
        public event EventHandler<Track> OnTrackComplete;
        private int GuiThreadId;
        private readonly Control control;
        public MediaPlayer(..., Control control){
          ...
          this.GuiThreadId = Thread.CurrentThread.ManagedThreadId;
          this.contrl = control;
        }
        public void Play(){
            Task t = Task.Factory.StartNew(() =>
            {
                //On Song complete
                FireOnTrackComplete();
            });
        }
        protected virtual void FireOnTrackComplete()
        {
            var trackComplete = OnTrackComplete;
            if (onTrackComplete != null)
                this.control.Invoke((MethodInvoker) delegate {trackComplete(this, loadedTrack);});
        }
    }
