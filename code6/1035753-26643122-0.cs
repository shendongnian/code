    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        // reload the slider value
        slider.Value = Settings.Slider.Value;
        base.OnNavigatedTo(e);
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        // save the slider value before exiting
        Settings.Slider.Value = (int)slider.Value;
        base.OnNavigatedFrom(e);
    }
    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
         // leave this alone unless the slider actually does something like changing the Opacity of an Image object
    }
