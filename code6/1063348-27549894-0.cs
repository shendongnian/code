    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    namespace CsiChart
    {
        public partial class CustomControl1 : Control
        {
            private const float EPSILON = 1e-6f;
    
            private Image _image;
            private ImageLayout _imageLayout = ImageLayout.Center;
            private PointF _pointA = new PointF(0, 100);
            private PointF _pointB = new PointF(100, 0);
    
            public CustomControl1()
            {
                InitializeComponent();
            }
    
            public Image Image
            {
                get { return _image; }
                set
                {
                    if (Equals(_image, value)) return;
                    _image = value;
                    Invalidate();
                    OnImageChanged(EventArgs.Empty);
                }
            }
    
            public event EventHandler ImageChanged;
    
            public ImageLayout ImageLayout
            {
                get { return _imageLayout; }
                set
                {
                    if (Equals(_imageLayout, value)) return;
                    _imageLayout = value;
                    Invalidate();
                    OnImageLayoutChanged(EventArgs.Empty);
                }
            }
    
            public event EventHandler ImageLayoutChanged;
    
            public PointF PointA
            {
                get { return _pointA; }
                set
                {
                    if (Equals(_pointA, value)) return;
                    _pointA = value;
                    Invalidate();
                    OnPointAChanged(EventArgs.Empty);
                }
            }
    
            public event EventHandler PointAChanged;
    
            public PointF PointB
            {
                get { return _pointB; }
                set
                {
                    if (Equals(_pointB, value)) return;
                    _pointB = value;
                    Invalidate();
                    OnPointBChanged(EventArgs.Empty);
                }
            }
    
            public event EventHandler PointBChanged;
    
            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);
                if (DesignMode) return;
    
                var g = pe.Graphics;
                g.Clear(BackColor);         
    
                var image = Image;
                if (image == null) return;
    
                var clientRectangle = ClientRectangle;
                var centerX = clientRectangle.X + clientRectangle.Width / 2;
                var centerY = clientRectangle.Y + clientRectangle.Height / 2;
    
                var srcRect = new Rectangle(new Point(0, 0), image.Size);
    
                var pointA = PointA;
                var pointB = PointB;
    
                // Compute U, AB vector normalized.
                var vx = pointB.X - pointA.X;
                var vy = pointB.Y - pointA.Y;
                var vLength = (float) Math.Sqrt(vx*vx + vy*vy);
                if (vLength < EPSILON)
                {
                    vx = 0;
                    vy = 1;
                }
                else
                {
                    vx /= vLength;
                    vy /= vLength;
                }
    
                var oldTransform = g.Transform;
    
                // Change basis to U,V
                // We also take into acount the inverted on screen Y.
                g.Transform = new Matrix(-vy, vx, -vx, -vy, centerX, centerY);
    
                var imageWidth = image.Width;
                var imageHeight = image.Height;
    
                RectangleF destRect;
                switch (ImageLayout)
                {
                    case ImageLayout.None:
                        destRect = new Rectangle(0, 0, imageWidth, imageHeight);
                        break;
                    case ImageLayout.Center:
                        destRect = new Rectangle(-imageWidth/2, -imageHeight/2, imageWidth, imageHeight);
                        break;
                    case ImageLayout.Zoom:
                        // XY aligned bounds size of the image.
                        var imageXSize = imageWidth*Math.Abs(vy) + imageHeight*Math.Abs(vx);
                        var imageYSize = imageWidth*Math.Abs(vx) + imageHeight*Math.Abs(vy);
    
                        // Get best scale to fit.
                        var s = Math.Min(clientRectangle.Width/imageXSize, clientRectangle.Height/imageYSize);
                        destRect = new RectangleF(-imageWidth*s/2, -imageHeight*s/2, imageWidth*s, imageHeight*s);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
    
                g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
                g.Transform = oldTransform;
            }
    
            protected virtual void OnImageChanged(EventArgs eventArgs)
            {
                var handler = ImageChanged;
                if (handler == null) return;
                handler(this, eventArgs);
            }
    
            protected virtual void OnImageLayoutChanged(EventArgs eventArgs)
            {
                var handler = ImageLayoutChanged;
                if (handler == null) return;
                handler(this, eventArgs);
            }
    
            private void OnPointAChanged(EventArgs eventArgs)
            {
                var handler = PointAChanged;
                if (handler == null) return;
                handler(this, eventArgs);
            }
    
            private void OnPointBChanged(EventArgs eventArgs)
            {
                var handler = PointBChanged;
                if (handler == null) return;
                handler(this, eventArgs);
            }
        }
    }
