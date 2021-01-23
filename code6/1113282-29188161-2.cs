    void OnStackPanelLoaded(..)
    {
        StackPanel.VerticalAlingment = VerticalAlingment.Bottom;
        StackPanel.RenderTransform = new TranslateTransform(0, StackPanel.ActualHeight); 
       // translate stackpanel out of page, be sure stackpanel has bottom alingment of grid
    }
    void OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs args)
    {
        var stackPanelTransform = MyStackPanel.RenderTransform as TranslateTransform;
        stackPanelTransform.Y += args.Delta.Translation.Y;
    }
