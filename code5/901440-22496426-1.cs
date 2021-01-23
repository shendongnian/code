    Image<Gray, Byte> canny = new Image<Gray, byte>(grayImage.Size);
         using (MemStorage storage = new MemStorage())
         for (Contour<Point> contours =grayImage.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, storage); contours != null; contours = contours.HNext)
         {
             //Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);
             CvInvoke.cvDrawContours(canny, contours, new MCvScalar(255), new MCvScalar(255), -1, 1, Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED, new Point(0, 0));
         }
    using (MemStorage store = new MemStorage())
             for (Contour<Point> contours1= grayImage.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, store); contours1 != null; contours1 = contours1.HNext)
             {
                 Rectangle r = CvInvoke.cvBoundingRect(contours1, 1);
                 canny.Draw(r, new Gray(255), 1);
             }
