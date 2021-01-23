        // New private field.  This enumerator stores our current position
        // iterating through the media files.
        private IEnumerator<music> files;
        private void AddMusictoList(List<music> pMusic)
        {
            this.files = pMusic.GetEnumerator();
            AddNextMusicFileIfExists();
        }
        // Starts loading the next file, if there is a next one.
        // If there isn't a next one, stops the media element.
        private void AddNextMusicFileIfExists()
        {
            if (this.files.MoveNext())
            {
                music iMusic = this.files.Current;
                Uri path = new Uri(iMusic.path);
                getDetails.Source = path;
                getDetails.Play();
            }
            else
            {
                getDetails.Stop();
            }
        }
        // I've replaced the MessageBoxes in this method with a call to
        // Debug.WriteLine, to prevent you getting spammed with lots of
        // message boxes.
        private void getDetails_MediaOpened(object sender, RoutedEventArgs e)
        {
            this.files.Current.duration = getDetails.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss");
            System.Diagnostics.Debug.WriteLine(this.files.Current.duration);
            this.musicList.Items.Add(this.files.Current);
            AddNextMusicFileIfExists();
        }
