    private void image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
       if (e.LeftButton == MouseButtonState.Pressed)
       {
          //This prevents win7 aerosnap
          if (this.ResizeMode != System.Windows.ResizeMode.NoResize)
          {
             this.ResizeMode = System.Windows.ResizeMode.NoResize;
             this.UpdateLayout();
             DragMove();
             this.ResizeMode = System.Windows.ResizeMode.CanResizeWithGrip;
          }
          else
             DragMove();
       }
    }
