    private void slider_MouseMove(object sender, MouseEventArgs e)
    {
       if (!floatingTip.IsOpen) { floatingTip.IsOpen = true; }
    
       Point currentPos = e.GetPosition(slider);
       Track _track = slider.Template.FindName("PART_Track", slider) as Track;
    
       sliderTextBlock.Text = _track.ValueFromPoint(currentPos).ToString();
    
       floatingTip.HorizontalOffset = currentPos.X -(floatingTipBorder.ActualWidth / 2);
       floatingTip.VerticalOffset = -32;
    }
    
    private void slider_MouseLeave(object sender, MouseEventArgs e)
    {
       floatingTip.IsOpen = false;
    }
