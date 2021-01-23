     protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
     {
          base.OnMouseLeftButtonDown(e);
          
          if (e.LeftButton == MouseButtonState.Pressed)
          {
              this.DragMove();
          }
     }
