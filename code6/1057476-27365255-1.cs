    class MediaPlayer {
        public MediaPlayer() {
            callersCtx = System.Threading.SynchronizationContext.Current;
            //...
        }
        private void FireOnTrackComplete() {
            if (callersCtx == null) FireOnTrackCompleteImpl();
            else callersCtx.Post(new System.Threading.SendOrPostCallback((_) => FireOnTrackCompleteImpl()), null);
        }
        protected virtual void FireOnTrackCompleteImpl() {
            var handler = OnTrackComplete;
            if (handler != null) handler(this, loadedTrack);
        }
        private System.Threading.SynchronizationContext callersCtx;
    }
