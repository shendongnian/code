    void TemperatureSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        if (TemperatureSlider.Value != 0)
        {
            ContinueButton.Visibility = Visibility.Visible;
        }
    }
