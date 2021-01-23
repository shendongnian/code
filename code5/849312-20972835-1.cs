            private void GestureListener_Tap(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
            {
            try
            {
            Point tapLocation = e.GetPosition(viewfinderCanvas);
            if (tapLocation != null)
            {
                focusBracket.SetValue(Canvas.LeftProperty,tapLocation.X);
                focusBracket.SetValue(Canvas.TopProperty, tapLocation.Y);
                double tapX = tapLocation.X;
                double tapY = tapLocation.Y;
                focusBracket.Visibility = Visibility.Visible;
            this.Dispatcher.BeginInvoke(delegate()
            {
            this.txtDebug.Text = string.Format("Tapping Coordinates are X={0:N2}, Y={1:N2}", tapX, tapY);
            });
            }
            }
            catch (Exception error){
            this.Dispatcher.BeginInvoke(delegate()
            {
            txtDebug.Text = error.Message;
            
            });
           
            }
            
        }
