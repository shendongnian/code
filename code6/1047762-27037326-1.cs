        <Rectangle Width="100" Height="100" MouseUp="UIElement_OnMouseUp" MouseDown="UIElement_OnMouseDown" Fill="Black"></Rectangle>
        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isMouseDownInRect)
            {
              // My code  
            }
            isMouseDownInRect = false;
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDownInRect = true;
        }
