    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        this.Loaded += PageLoaded;
        this.Unloaded += PageUnloaded;
     }
    
     private void PageUnloaded(object sender, RoutedEventArgs e)
     {
         Window.Current.SizeChanged -= Window_SizeChanged;
     }
    
     private void PageLoaded(object sender, RoutedEventArgs e)
     {
         Window.Current.SizeChanged += Window_SizeChanged;
     }
    
     private void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
     {
         if (e.Size.Width <= 500)
         {
         //VisualStateManager.GoToState(this, state.State, transitions);
         }
         else if (e.Size.Height > e.Size.Width)
         {
         //VisualStateManager.GoToState(this, state.State, transitions);
         }
         else
         {
         //VisualStateManager.GoToState(this, state.State, transitions);
         }
     }
