        public event EventHandler<SpeechEventArgs> SpeakCompleted;
        public void SpeakAsync(string text, string language)
        {
            this.GetSpeakStreamAsyncHelper(text, language, result =>
            {
                if (result.Error == null)
                {
                    SoundEffect effect = SoundEffect.FromStream(result.Stream);
                    FrameworkDispatcher.Update();
                    effect.Play();
                    this.OnSpeakCompleted(new SpeechEventArgs(result.Error));            // added to call completion handler
                }
                else
                {
                    this.OnSpeakFailed(new SpeechEventArgs(result.Error));
                }
            });
        }
    // new function
        private void OnSpeakCompleted(SpeechEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (SpeakCompleted != null)
                    SpeakCompleted(this, e);
            });
        }
