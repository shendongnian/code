            ImageBrush image = new ImageBrush();
            if (IsWvga)
            {
                //set your bitmap
            }
            else if (IsWxga)
            {
                //set your bitmap
            }
            else if (Is720p)
            {
                //set your bitmap
            }
            else if(IsHD)
            {
               //set your bitmap
            }
            image.Stretch = Stretch.UniformToFill;
            LayoutRoot.Background = image;
