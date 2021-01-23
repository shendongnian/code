            private void MouseLeftButtonDown(object sender, MouseEventArgs e)
            {
                mouseDown = true;
                oldMousePosition = AssociatedObject.PointToScreen(e.GetPosition(AssociatedObject));
                AssociatedObject.Child.CaptureMouse();
                e.Handled = true;
            }
