     private void LayoutGrid_OnPointerPressed(object sender, PointerRoutedEventArgs e)
            {
                MagnifierTip.Visibility = Windows.UI.Xaml.Visibility.Visible;
    
                var point = e.GetCurrentPoint(this.LayoutGrid);
                this.pointerX = point.Position.X;
                this.pointerY = point.Position.Y;
                this.UpdateMagnifier();
            }
