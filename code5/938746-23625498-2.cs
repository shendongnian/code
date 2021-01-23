            RotateTransform rt = new RotateTransform
            rt.CenterX = actualWidth / 2;
            rt.CenterY = actualHeight / 2;
            if (imageWidth > imageHeight)
            {
                //Landscape
                rt.Angle = 0;
                Debug.WriteLine("Display image in LANDSCAPE");
            }
            else if (imageWidth == imageHeight)
            {
                //Portrait
                rt.Angle = 90;
                Debug.WriteLine("Display image in PORTRAIT");
            }
            else
            {
                //Portrait
                rt.Angle = 90;
                Debug.WriteLine("Display image in PORTRAIT");
            }
            grid.Children.Add(img);
            popUp.Child = grid; //set child content
            this.LayoutRoot.Children.Add(popUp);
            popUp.IsOpen = true;
