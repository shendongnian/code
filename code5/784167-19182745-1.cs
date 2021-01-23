       private MediaElement globalMediaElement = null;
        private void OnGlobalMediaLoaded(object sender, RoutedEventArgs e)
        {
            if (this.globalMediaElement == null)
                this.globalMediaElement = sender as MediaElement;
        }
        public   void playMedia(Uri source)
        {
            this.globalMediaElement.Source = source;
            this.globalMediaElement.Play();
        }
        public void stopMedia()
        {
            this.globalMediaElement.Stop();
        }
