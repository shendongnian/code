        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image image = new Image();
            
            image.Source = imgPlayer.Source;
            //This is important
            image.Stretch = Stretch.Uniform;
            // Find the full size of the page
            Size pageSize =  new Size(e.PrintableArea.Width  + e.PageMargins.Left + e.PageMargins.Right, e.PrintableArea.Height + e.PageMargins.Top + e.PageMargins.Bottom);
 
            var MARGIN= 10;
            // Get additional margins to bring the total to MARGIN (= 96)
            Thickness additionalMargin = new Thickness
            {
                Left = Math.Max(0, MARGIN - e.PageMargins.Left),
                Top = Math.Max(0, MARGIN - e.PageMargins.Top),
                Right = Math.Max(0, MARGIN - e.PageMargins.Right),
                Bottom = Math.Max(0, MARGIN - e.PageMargins.Bottom)
            };
 
            // Find the area for display purposes
            Size displayArea = new Size(e.PrintableArea.Width - additionalMargin.Left - additionalMargin.Right,  e.PrintableArea.Height  - additionalMargin.Top - additionalMargin.Bottom);
 
            bool pageIsLandscape = displayArea.Width > displayArea.Height;
            bool imageIsLandscape = image.ActualWidth > image.ActualHeight;
 
            double displayAspectRatio = displayArea.Width / displayArea.Height;
            double imageAspectRatio = (double)image.ActualWidth / image.ActualHeight;
 
            double scaleX = Math.Min(1, imageAspectRatio / displayAspectRatio);
            double scaleY = Math.Min(1, displayAspectRatio / imageAspectRatio);
 
            // Calculate the transform matrix
            MatrixTransform transform = new MatrixTransform();
 
            if (pageIsLandscape == imageIsLandscape)
            {
            // Pure scaling
                transform.Matrix = new Matrix(scaleX, 0, 0, scaleY, 0, 0);
            }
            else
            {
                // Scaling with rotation
                scaleX *= pageIsLandscape ? displayAspectRatio : 1 /   displayAspectRatio;
                scaleY *= pageIsLandscape ? displayAspectRatio : 1 /   displayAspectRatio;
                transform.Matrix = new Matrix(0, scaleX, -scaleY, 0, 0, 0);
            }
 
            Image image2 = new Image
            {
                Source = image.Source,
                Stretch = Stretch.Fill,
                Width = displayArea.Width,
                Height = displayArea.Height,
                RenderTransform = transform,
                RenderTransformOrigin = new Point(0.5, 0.5),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = additionalMargin,
            };
 
            Border border = new Border
            {
                Child = image,
            };
 
            e.PageVisual = border;
        }
