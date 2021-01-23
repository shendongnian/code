    private void rec_overlay_ManipulationDelta(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
    {
        // keep the Opacity value within its boundary
        if (rec_overlay.Opacity > 1)
        {
            rec_overlay.Opacity = 1;
        }
        else if (rec_overlay.Opacity < 0)
        {
            rec_overlay.Opacity = 0;
        }
    
        // update the opacity whenever a movement happens
        rec_overlay.Opacity += -e.Delta.Translation.Y / this.rec_overlay.ActualHeight;
    }
