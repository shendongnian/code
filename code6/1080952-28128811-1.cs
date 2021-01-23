    private void btnVolumeUp_Click(object sender, RoutedEventArgs e)
    {
        if (videoMediaElement.IsMuted)
        {
            videoMediaElement.IsMuted = false;
        }
        if (videoMediaElement.Volume > 0)
        {
            videoMediaElement.Volume -= .1;
        }
    }
    private void btnVolumeDown_Click(object sender, RoutedEventArgs e)
    {
        if (videoMediaElement.IsMuted)
        {
            videoMediaElement.IsMuted = false;
        }
        if (videoMediaElement.Volume < 1)
        {
            videoMediaElement.Volume += .1;
        }
    }
