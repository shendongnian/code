          SoundEffectInstance instance;
    private void Button1_Click(object sender, RoutedEventArgs e)
        {
                    StreamResourceInfo info = Application.GetResourceStream(new Uri("Assets/Sound/test1.wav", UriKind.Relative));
                    SoundEffect sound = SoundEffect.FromStream(info.Stream);
                    if (instance != null)
                        instance.Stop();
                    instance = sound.CreateInstance();
                    instance.Play();
         }
        
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
                    StreamResourceInfo info = Application.GetResourceStream(new Uri("Assets/Sound/test2.wav", UriKind.Relative));
                    SoundEffect sound = SoundEffect.FromStream(info.Stream);
                    if (instance != null)
                        instance.Stop();
                    instance = sound.CreateInstance();
                    instance.Play();
        }
