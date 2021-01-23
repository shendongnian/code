    class MediaPlayer {
        public MediaPlayer() {
            callersCtx = System.Threading.SynchronizationContext.Current;
            //...
        }
        protected virtual void FireOnTrackComplete() {
            if (callersCtx != null && OnTrackComplete != null) {
                callersCtx.Post(new System.Threading.SendOrPostCallback((_) => FireOnTrackComplete()), null);
            }
            else {
                var handler = OnTrackComplete;
                if (handler != null) handler(this, loadedTrack);
            }
        }
        private System.Threading.SynchronizationContext callersCtx;
    }
