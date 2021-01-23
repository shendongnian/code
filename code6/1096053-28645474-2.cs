    public partial class ScaledPictureBox : PictureBox
    {
        float Zoom { get; set; }
        Matrix ScaleM { get; set; }
        Size ImgSize { get; set; }
        // these points get scaled when zooming in or out:
        public List<PointF> ScaledPoints = new List<PointF>();
        public ScaledPictureBox()
        {
            InitializeComponent();
            ScaleM = new Matrix();
            SizeMode = PictureBoxSizeMode.Zoom;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            // here we scale the Graphics:
            pe.Graphics.MultiplyTransform(ScaleM);
        }
        // a convenience function for setting up a loaded image
        public void InitImage()
        {
            if (Image != null)
            {
                ImgSize = Image.Size;
                Size = ImgSize;
                setZoom(100);
            }
        }
        public void setZoom(float zoomfactor)
        {
            if (zoomfactor <= 0) throw new Exception("Zoom must be positive");
            float oldZoom = Zoom;
            Zoom = zoomfactor / 100f;
            ScaleM.Scale(Zoom , Zoom );
            // zoom the Image by changing the PB's size:
            if (ImgSize != Size.Empty) Size = 
                       new Size((int)(ImgSize.Width * Zoom), (int)(ImgSize.Height * Zoom));
            // here we rescale all point in the list
            for (int i = 0; i < ScaledPoints.Count; i++ )
            {
                ScaledPoints[i] = new PointF(ScaledPoints[i].X * Zoom / oldZoom, 
                                             ScaledPoints[i].Y * Zoom / oldZoom);
            }
        }
        // a function to test the scaling
        public void DrawPoint(Graphics G, float x, float y, Pen pen)
        {
            using (SolidBrush brush = new SolidBrush(pen.Color))
            {
                // changing the pen with with the zoom:
                float pw = pen.Width * Zoom;
                float pr = pw / 2f;
                G.FillEllipse(brush, new RectangleF(x - pr, y - pr, pw, pw));
            }
        }
    }
