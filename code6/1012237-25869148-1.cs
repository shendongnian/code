    private void SizeChanged(object sender, SizeChangedEventArgs e)
    {
         UpdateVisualState();
    }
 
    private void UpdateVisualState()
    {
        var state = string.Empty;
        // calculate state here (Normal vs Maximized)
        VisualStateManager.GoToState(this, state, true);
    }
