    var sb1 = (Storyboard)mainWindow.FindResource("Storyboard1");
    var sb2 = (Storyboard)mainWindow.FindResource("Storyboard2");
    var sb3 = (Storyboard)mainWindow.FindResource("Storyboard3");
    Task.WhenAll( new Task[] {
        sb1.BeginAsync(),
        sb2.BeginAsync(),
        sb3.BeginAsync() })
        .ContinueWith(() => MessageBox.Show("All done!"),
            TaskScheduler.FromCurrentSynchronizationContext());
