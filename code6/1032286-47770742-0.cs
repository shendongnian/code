    public static class FullImage
    {
        public static Image image;  
        public static RectangleF DisplayRect, SourceRect;
        public static Size ParentBoundry;
        public static float rotationangle=0;
     
        internal static void Paint(Graphics graphics)
        {
            if (image == null)
                return;
            float hw = DisplayRect.X + DisplayRect.Width / 2f;
            float hh = DisplayRect.Y + DisplayRect.Height / 2f;
            System.Drawing.Drawing2D.Matrix m = graphics.Transform;
            m.RotateAt(rotationangle, new PointF(hw, hh), System.Drawing.Drawing2D.MatrixOrder.Append);
            graphics.Transform = m;
            graphics.DrawImage(image, new RectangleF(DisplayRect.X, DisplayRect.Y, DisplayRect.Width, DisplayRect.Height), SourceRect, GraphicsUnit.Pixel);
            graphics.ResetTransform();
        }
        
        public static void LoadImage(Image img)
        {         
            image = img;
            SizeF s = GetResizedSize(image, ParentBoundry);
            SourceRect = new RectangleF(0, 0, image.Width, image.Height);
            DisplayRect =  new RectangleF(ParentBoundry.Width / 2 - s.Width / 2, ParentBoundry.Height / 2 - s.Height / 2, s.Width, s.Height);
        }
      
        public static Size GetResizedSize(Image ImageToResize, Size size)
        {
            int sourceWidth = ImageToResize.Width;
            int sourceHeight = ImageToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            return new Size(destWidth, destHeight);
        }
        internal static void MouseWheel(int delta)
        {
                   
            if (delta > 0)
                DisplayRect = ZoomImage(DisplayRect,CurrentMouse, .1f);
            else
                DisplayRect = ZoomImage(DisplayRect, CurrentMouse, -.1f);
        }
    private RectangleF ZoomImage(RectangleF ImageRectangle, PointF MouseLocation, float ScaleFactor)
        {
            /// Original Size and Location
            SizeF OriginalSize = ImageRectangle.Size;
            PointF OriginalPoint = ImageRectangle.Location;
            ///Mouse cursor location -located in width% and height% of totaloriginal image
            float mouse_widthpercent = System.Math.Abs(OriginalPoint.X - MouseLocation.X) / OriginalSize.Width * 100;
            float mouse_heightpercent = System.Math.Abs(OriginalPoint.Y - MouseLocation.Y) / OriginalSize.Height * 100;
            ///Zoomed Image by scalefactor
            SizeF FinalSize = new SizeF(OriginalSize.Width + OriginalSize.Width * ScaleFactor, OriginalSize.Height + OriginalSize.Height * ScaleFactor);
            if (FinalSize.Width < 15 || FinalSize.Height < 15)
                return ImageRectangle;
            if (FinalSize.Width > 60000 || FinalSize.Height > 60000)
                return ImageRectangle;
            /// How much width increases and height increases
            float widhtincrease = FinalSize.Width - OriginalSize.Width;
            float heightincrease = FinalSize.Height - OriginalSize.Height;
            /// Adjusting Image location after zooming the image
            PointF FinalLocation = new System.Drawing.PointF(OriginalPoint.X - widhtincrease * mouse_widthpercent / 100,
                  OriginalPoint.Y - heightincrease * mouse_heightpercent / 100);
            ImageRectangle = new RectangleF(FinalLocation.X, FinalLocation.Y, FinalSize.Width, FinalSize.Height);
            return ImageRectangle;
        }
        static bool drag = false;
        static Point Initial, CurrentMouse;  
        internal static void MouseMove(Point location)
        {          
            CurrentMouse = location;
            if (drag)
            {
                DisplayRect = new RectangleF(DisplayRect.X + location.X - Initial.X, DisplayRect.Y + location.Y - Initial.Y, DisplayRect.Width, DisplayRect.Height);
                Initial = location;
            }
        }
        internal static void MouseDown(Point location)
        {       
            Initial = location;
            drag = true;
        }
        internal static void MouseUp(Point location)
        {
            drag = false;
        }        
    }
