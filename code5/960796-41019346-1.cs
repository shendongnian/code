    private void OnViewLoaded(object sender, RoutedEventArgs e)
    {
        // Passing Plotter to ViewModel
        ViewModel.InnerPlotter = InnerPlotter;
        Plotter.Viewport.PropertyChanged += Viewport_PropertyChanged;
    }
    
    private void Viewport_PropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
    {
        // Update Viewport of Inner Plotter
        InnerPlotter.Viewport.Visible = new DataRect(
            Plotter.Viewport.Visible.XMin,
            InnerPlotter.Viewport.Visible.YMin,
            Plotter.Viewport.Visible.Width,
            InnerPlotter.Viewport.Visible.Height
            );
    }
