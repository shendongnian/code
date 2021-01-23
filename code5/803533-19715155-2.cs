    public class CustomLabel : Label {
        public CustomLabel() {
            BackColor = base.BackColor;
            base.BackColor = Color.Transparent;
            DoubleBuffered = true;                     
        }
        Color backColor;
        int alpha;
        public new Color BackColor {
            get { return backColor; }
            set { 
               backColor = value;
               alpha = value.A;
               if (alpha < 255) backColor = Color.FromArgb(value.R, value.G, value.B);
               UpdateVisual(true);               
            }
        }        
        protected override void OnForeColorChanged(EventArgs e) {
            base.OnForeColorChanged(e);
            if (ForeColor == Color.Transparent) {
                base.BackColor = Color.Transparent;
                UpdateVisual(true);
            } else {
                base.BackColor = BackColor;
                BackgroundImage = null;
            }
        }
        Image img;        
        private void UpdateVisual(bool applyChange) {     
            img = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(img)){
                g.Clear(BackColor);             
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;                
                g.DrawString(Text, Font, Brushes.Black, ClientRectangle);
            }
            Bitmap bm = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(bm)) {
                g.SmoothingMode = SmoothingMode.HighSpeed;
                ImageAttributes ia = new ImageAttributes();
                List<ColorMap> cms = new List<ColorMap>();                
                for (decimal f = 0; f < 1; f += 0.001M) {
                    ColorMap cm = new ColorMap();
                    cm.NewColor = Color.FromArgb((int)((1 - f) * alpha), BackColor);
                    cm.OldColor = GetNormalBlendColor(BackColor,Color.Black, f);                    
                    cms.Add(cm);
                }              
                ia.SetRemapTable(cms.ToArray());                                
                g.DrawImage(img, new Point[] {Point.Empty, new Point(img.Width, 0), new Point(0,img.Height) }, new Rectangle() {Size = bm.Size}, GraphicsUnit.Pixel, ia);
            }
            img.Dispose();          
            img = bm;
            if (applyChange) BackgroundImage = img;
        }
        public Color GetNormalBlendColor(Color baseColor, Color blendColor, decimal opacity) {
            int R = Math.Min((int)((1 - opacity) * baseColor.R + blendColor.R * opacity), 255);
            int G = Math.Min((int)((1 - opacity) * baseColor.G + blendColor.G * opacity), 255);
            int B = Math.Min((int)((1 - opacity) * baseColor.B + blendColor.B * opacity), 255);                        
            return Color.FromArgb(R, G, B);
        }
        protected override void OnPaint(PaintEventArgs e) {
            if (ForeColor != Color.Transparent) {
                using (Brush brush = new SolidBrush(BackColor)) {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
                base.OnPaint(e);
            }                        
        }      
        protected override void OnTextChanged(EventArgs e) {
            base.OnTextChanged(e);
            if(ForeColor == Color.Transparent) UpdateVisual(true);
        }
        protected override void OnFontChanged(EventArgs e) {
            base.OnFontChanged(e);
            if(ForeColor == Color.Transparent) UpdateVisual(true);
        }
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            if (ForeColor == Color.Transparent) UpdateVisual(true);          
        }
        
    }
