    private async void GestureListener_PinchCompleted(object sender, PinchGestureEventArgs e)
    {
        progressBar.Visibility = System.Windows.Visibility.Visible;
        await Task.Run(()=> DoWork()); //quite long (4-5 seconds)
        progressBar.Visibility = System.Windows.Visibility.Collapsed;
    }
