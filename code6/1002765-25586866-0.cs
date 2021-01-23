    this.Unloaded += new RoutedEventHandler(AnimatedImage_Unloaded);
 
    void AnimatedImage_Unloaded(object sender, RoutedEventArgs e)
    {
        Stop();
    }
 
