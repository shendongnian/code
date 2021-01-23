    public Image<Bgr, Byte> Resize(Image<Bgr, Byte> im)
            {
                return im.Resize(64, 128, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            }
            public float[] GetVector(Image<Bgr, Byte> im)
            {
                HOGDescriptor hog = new HOGDescriptor();    // with defaults values
                Image<Bgr, Byte> imageOfInterest = Resize(im);
                Point[] p = new Point[imageOfInterest.Width * imageOfInterest.Height];
                int k = 0;
                for (int i = 0; i < imageOfInterest.Width; i++)
                {
                    for (int j = 0; j < imageOfInterest.Height; j++)
                    {
                        Point p1 = new Point(i, j);
                        p[k++] = p1;
                    }
                }
    
                return hog.Compute(imageOfInterest, new Size(8, 8), new Size(0, 0), p);
            }
