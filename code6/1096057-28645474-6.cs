    public partial class ScaledPictureBox : PictureBox
    {
        public Matrix ScaleM { get; set; }
        float Zoom { get; set; }
        Size ImgSize { get; set; }
        public ScaledPictureBox()
        {
            InitializeComponent();
            ScaleM = new Matrix();
            SizeMode = PictureBoxSizeMode.Zoom;
        }
        public void InitImage()
        {
            if (Image != null)
            {
                ImgSize = Image.Size;
                Size = ImgSize;
                SetZoom(100);
            }
        }
        public void SetZoom(float zoomfactor)
        {
            if (zoomfactor <= 0) throw new Exception("Zoom must be positive");
            float oldZoom = Zoom;
            Zoom = zoomfactor / 100f;
            ScaleM.Reset();
            ScaleM.Scale(Zoom , Zoom );
            if (ImgSize != Size.Empty) Size = new Size((int)(ImgSize.Width * Zoom), 
                                                       (int)(ImgSize.Height * Zoom));
        }
        public PointF ScalePoint(PointF pt)
        {   return new PointF(pt.X / Zoom , pt.Y / Zoom );     }
    }
