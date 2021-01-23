    private int _lastSliderValue = 100;
    private void sw_music_Toggle(object sender, RoutedEventArgs e)
    {
        if(slider.Value >= 1) // I think you don't need this
        {
            if (sw_music.IsOn)
            {
                slider.Value = _lastSliderValue;
                Intro_Sound.Play();
            }
            else
            {
                _lastSliderValue = slider.Value;
                slider.Value = 0;
                Intro_Sound.Stop();
            }
            if(slider.Value > 1)
            {
                Intro_Sound.Play();
                sw_music.IsOn = true;
            }
        }
    }
