      private bool CheckLines(Bitmap image, Color filterColor)
        {
            EuclideanColorFiltering ColorFilter = new EuclideanColorFiltering();
            // set center colour and radius
            AForge.Imaging.RGB color = new RGB(filterColor.R, filterColor.G, filterColor.B, filterColor.A);
            ColorFilter.CenterColor = color;
            ColorFilter.Radius = 100;
            // Apply the filter
            ColorFilter.ApplyInPlace(image);
            // Define the Blob counter and use it!
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinWidth = 5;
            blobCounter.MinHeight = 5;
            blobCounter.FilterBlobs = true;
            //blobCounter.ObjectsOrder = ObjectsOrder.Size;
            blobCounter.ProcessImage(image);
            System.Drawing.Rectangle[] rects = blobCounter.GetObjectsRectangles();
            if (rects.Length > 0)
            {
                return true;
            }
            return false;
        }
