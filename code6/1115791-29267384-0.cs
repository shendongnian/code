    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
    {
        m_SoundPlayer.Stop();
        m_SoundPlayer.Open(new Uri(szPath, UriKind.Relative));
        m_SoundPlayer.Play();
    }));
