        private void InkCanvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!mouseInputEnabled)
                e.Handled = true;
        }
        private void InkCanvas_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (!stylusInputEnabled)
                e.Handled = true;
        }
        private void InkCanvas_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }
