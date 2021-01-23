     private void GenericZoomHandler(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(ZoomOut))   //if sender is ZoomOut object
            {
                slider1.Value -= .15;     //decrement by 15%
            }
            else if (sender.Equals(ZoomIn))   //if sender is ZoomIn object
            {
                slider1.Value += .15;    //increment by 15%
            }
            else if (sender.Equals(Zoom100))   //if sender is Zoom100 object
            {
                slider1.Value = 1.0;        //return to original size of image     (100%)
            }
        }
