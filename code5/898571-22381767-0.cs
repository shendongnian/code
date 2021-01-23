        protected override async void OnResume()
        {
            base.OnResume ();
            StartAnimate ();
            await RunAsync (TimeSpan.FromSeconds (4));
            StopAnimate ();
        }
        private async Task RunAsync(TimeSpan span)
        {
            await Task.Delay (span);
        }
        private void StartAnimate()
        {
            // put animation here
        }
        private void StopAnimate()
        {
            // stop animating after the thread has ended
        }
