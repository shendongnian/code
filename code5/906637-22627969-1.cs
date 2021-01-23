            image.Height = 300;
            image.Width = 400;
            if (image.Height > image.Width)
            {
                compositeTransform.Rotation = 0.0;
            }
            else
            {
                compositeTransform.Rotation = 90.00;
            }
            image.Source =(ImageSource) new ImageSourceConverter().ConvertFromString("2011-Chrysler-300-Model-09-1024x1280.jpg");
