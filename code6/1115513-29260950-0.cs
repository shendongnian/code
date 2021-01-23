     protected Point TouchStart;
            private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
            {
                TouchStart = e.GetPosition(this);
                MyButton.Background = Brushes.Red;
    
            }
        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
                var touch = e.GetPosition(this);
         
            if (touch.X >= (TouchStart.X + 99)) //button with here
            {
                MyButton.Background = Brushes.Aquamarine;
            }
        }
