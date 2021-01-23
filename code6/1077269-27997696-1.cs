    Random ran = new Random();
    private void MoveRectangle_Completed(object sender, object e) {
      xKey1.Value = xKey2.Value;
      xKey2.Value = ran.NextDouble() * (MainCanvas.ActualWidth - TestRectangle.ActualWidth);
      yKey1.Value = yKey2.Value;
      yKey2.Value = ran.NextDouble() * (MainCanvas.ActualHeight - TestRectangle.ActualHeight);
    
    }
    
    private void rectangle_Tapped(object sender, TappedRoutedEventArgs e) {
      MoveRectangleStoryboard.Begin();
    }
