        /// <summary>
        /// Handles pressing Mouse Button over the Control.
        /// </summary>
        private void AssociatedObject_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.startPoint = e.GetPosition(base.AssociatedObject);
            base.AssociatedObject.CaptureMouse();
            e.Handled = true;
        }
