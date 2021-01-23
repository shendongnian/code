    private int count = 0;
            private void StackPanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (count == 0 && (sender as StackPanel).IsMouseOver)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    count++;
                }
    
                e.Handled = true;
            }
    
            private void StackPanel_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                if (count == 1 && (sender as StackPanel).IsMouseOver)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    count++;
                }
    
                e.Handled = true;
            }
