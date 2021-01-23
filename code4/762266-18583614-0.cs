    private double savedValue = 100;
    private void sw_music_Toggle(object sender, RoutedEventArgs e)
    {
        if(slider.Value >= 1)
        {
          if (sw_music.IsOn)
          {
            slider.Value = saveValue;
            Intro_Sound.Play();
          }
          else
          {
            saveValue = slider.Value;
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
