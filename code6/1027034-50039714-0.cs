        static List<Tuple<float,float>> ShapeToPoints(Microsoft.Office.Interop.PowerPoint.Shape shape)
        {
            string path = @"C:\Temp\bpmimg\Test1.png";
            if (File.Exists(path))
                File.Delete(path);
            List<Tuple<float, float>> points = new List<Tuple<float, float>>();
            try
            {
                //Shape.Export is an internal method, but we access it via reflection this way
                var args = new object[] { path, Microsoft.Office.Interop.PowerPoint.PpShapeFormat.ppShapeFormatPNG, 0, 0, Microsoft.Office.Interop.PowerPoint.PpExportMode.ppRelativeToSlide };
                shape.GetType().InvokeMember("Export", System.Reflection.BindingFlags.InvokeMethod, null, shape, args); // Export to file on disk
                // locating objects
                BlobCounter blobCounter = new BlobCounter();
                blobCounter.FilterBlobs = true;
                blobCounter.MinHeight = 5;
                blobCounter.MinWidth = 5;
                //Important that the dispose is called so that the temp-file cleanup File.Delete doesn't crash due to locked file
                using (System.Drawing.Bitmap image = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(path))
                {
                    blobCounter.ProcessImage(image);
                }
                Blob[] blobs = blobCounter.GetObjectsInformation();
                SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
                if (blobs.Length != 1)
                {
                    //Unexpected number of blobs
                    return null;
                }
                var blob = blobs[0];
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blob);
                List<IntPoint> untransformedPoints;
                // use the shape checker to extract the corner points
                if (!shapeChecker.IsConvexPolygon(edgePoints, out untransformedPoints))
                {
                    IConvexHullAlgorithm hullFinder = new GrahamConvexHull();
                    untransformedPoints = hullFinder.FindHull(edgePoints);
                }
                var untransformedWidth = untransformedPoints.Max(p => p.X);
                var untransformedHeight = untransformedPoints.Max(p => p.Y);
                var widthRatio = untransformedWidth / shape.Width;//How many time bigger is the image-based figure than the shape figure
                var heightRatio = untransformedHeight / shape.Height;//How many time bigger is the image-based figure than the shape figure
                points = untransformedPoints.Select(p => new Tuple<float, float>(shape.Left + p.X / widthRatio, shape.Top + p.Y / heightRatio)).ToList();//Transform
            }
            finally
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            return points;
        }
