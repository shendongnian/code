    private void tbx1_Leave(object sender, EventArgs e)
    {
        _str = tbx1.Text;
    }
    
    private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Slider slider1 = sender as Slider;
        _str = tbx1.Text = slider1.Value.ToString();
    }
