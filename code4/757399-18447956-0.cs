    private void MapItem_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
    {
        Scroller.IsEnabled = false;
    }
    private void MapItem_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
    {
        Scroller.IsEnabled = true;
    }
