        protected override void OnInitialized(EventArgs e)
        {
            PlaySound1.LoadedBehavior = MediaState.Manual;
            PlaySound2.LoadedBehavior = MediaState.Manual;
            PlaySound3.LoadedBehavior = MediaState.Manual;
            PlaySound1.Source = new Uri("aah-01.wav", UriKind.Relative);
            PlaySound2.Source = new Uri("crowd-groan.wav", UriKind.Relative);
            PlaySound3.Source = new Uri("laugh-01.wav", UriKind.Relative);
            base.OnInitialized(e);
        }
