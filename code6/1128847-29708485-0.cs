    bool isUpdating = false;
    private static void OnTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    { 
        if (!isUpdating)
        {
            isUpdating = true;
            MediaPlayer.Time = (long)e.NewValue;
            isUpdating = false;
        }
    }  
