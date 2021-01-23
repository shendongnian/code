    //The ValueChanged handler for your Slider
    private void slider_ValueChanged(object sender, 
                                     RoutedPropertyChangedEventArgs e){
       da.Duration = new Duration(TimeSpan.FromMilliseconds(yourSlider.Value));
       da.From = rt.Angle;
       rt.ApplyAnimationClock(RotateTransform.AngleProperty, da.CreateClock());
    }
