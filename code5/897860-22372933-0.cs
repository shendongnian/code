    if ((e.Orientation & PageOrientation.LandscapeLeft) == PageOrientation.LandscapeLeft)
            {
                rotate = false;
            }
            else if ((e.Orientation & PageOrientation.LandscapeRight) == PageOrientation.LandscapeRight)
            {
                rotate = true;
            }
            if ((e.Orientation & PageOrientation.Portrait) == (PageOrientation.Portrait))
            {
                if (!rotate) { 
                    CompositeTransform Trans = new CompositeTransform();
                    Trans.Rotation = 90;
                
                    Trans.TranslateY=-200;
                    Trans.TranslateX = -120;
                    Trans.CenterY = 400;
                    Trans.CenterX = 200;
                    popup.RenderTransform = Trans;
                }
                else
                {
                    CompositeTransform Trans = new CompositeTransform();
                    Trans.Rotation = -90;
                    Trans.TranslateY = 200;
                    Trans.TranslateX = 200;
                    Trans.CenterY = 400;
                    Trans.CenterX = 200;
                    popup.RenderTransform = Trans;
                }
                /*RotateTransform myRotateTransform = new RotateTransform();
                if (rotate)
                {
                    myRotateTransform.Angle = 90;
                    myRotateTransform.CenterY = popup.ActualHeight / 2;
                    myRotateTransform.CenterX = popup.ActualWidth / 2;
                    popup.RenderTransform = myRotateTransform;
                }*/
            
            }
            // If not in portrait, move buttonList content to visible row and column.
            else
            {
            }
      }
