        private double InitialScale;
        private Point firstTouch; 
        private Point secondTouch;
    
    private void GestureListener_PinchStarted(object sender, PinchStartedGestureEventArgs e)
            {
                // Store the initial scaling
                InitialScale = ImageTransformation.ScaleX;
    
                firstTouch = e.GetPosition(photo, 0);
                secondTouch = e.GetPosition(photo, 1);
    
            }
    
            private void OnPinchDelta(object sender, PinchGestureEventArgs e)
            {
                double difX;
                double difY;
                if (firstTouch.Y >= secondTouch.Y)
                {
                    difY = firstTouch.Y - secondTouch.Y;
                }
                else
                {
                    difY = secondTouch.Y - firstTouch.Y;
                }
    
                if (firstTouch.X >= secondTouch.X)
                {
                    difX = firstTouch.X - secondTouch.X;
                }
                else
                {
                    difX = secondTouch.X - firstTouch.X;
                }
    
                if (difX <= difY)
                {
                    if (difX < 50)
                    {
                        ImageTransformation.ScaleY = InitialScale * e.DistanceRatio;
                    }
                    else
                    {
                        ImageTransformation.ScaleX = InitialScale * e.DistanceRatio;
                        ImageTransformation.ScaleY = InitialScale * e.DistanceRatio;
                    }
                }
                else
                {
                    if (difY < 50)
                    {
                        ImageTransformation.ScaleX = InitialScale * e.DistanceRatio;
                    }
                    else
                    {
                        ImageTransformation.ScaleX = InitialScale * e.DistanceRatio;
                        ImageTransformation.ScaleY = InitialScale * e.DistanceRatio;
                    }
                }
            }
