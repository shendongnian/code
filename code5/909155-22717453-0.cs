            private void TestSnake()
        {
            Image<Gray, Byte> grayImg = new Image<Gray, Byte>(400, 400, new Gray());
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(400, 400, new Bgr(255,255,255));
            
            // draw an outer circle on gray image
            grayImg.Draw(new Ellipse(new PointF(200,200),new SizeF(100,100),0), new Gray(255.0), -1);
            // inner circle on gray image to create a donut shape :-)
            grayImg.Draw(new Ellipse(new PointF(200, 200), new SizeF(50, 50), 0), new Gray(0), -1);
         
            // this is the center point we'll use to initialize our contour points
            Point center = new Point(200, 200);
            // radius of polar points
            double radius = 70;
            using (MemStorage stor = new MemStorage())
            {
                
                Seq<Point> pts = new Seq<Point>((int)Emgu.CV.CvEnum.SEQ_TYPE.CV_SEQ_POLYGON, stor);                
                int numPoint = 100;
                for (int i = 0; i < numPoint; i++)
                {   // let's have some fun with polar coordinates                                
                    Point pt = new Point((int)(center.X + (radius * Math.Cos(2 * Math.PI * i / numPoint))), (int)(center.Y + (radius * Math.Sin(2 * Math.PI * i / numPoint))) );
                    pts.Push(pt);                                            
                }
                // draw contour points on result image
                img.Draw(pts, new Bgr(Color.Green), 2);
                // compute snakes                                
                Seq<Point> snake = grayImg.Snake(pts, 1.0f, 1.0f, 1.0f, new Size(21, 21), new MCvTermCriteria(100, 0.0002), stor);
                // draw snake result
                img.Draw(snake, new Bgr(Color.Yellow), 2);
 
                // use for display in a winform sample
                imageBox1.Image = grayImg;
                imageBox2.Image = img;
            }
        }
