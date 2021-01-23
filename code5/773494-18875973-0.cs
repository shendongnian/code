            Dispatcher.BeginInvoke(new Action(() =>
            {
                MusicSeekBar.Value = value; //MusicSeekBar is mine Slider
                CurrentValue.Content = value; //CurrentValue is a Label
            }));
