    public class ButtonX : Button {
        GraphicsPath border = new GraphicsPath();
        int radius = 3;
        float borderWidth;
        Color borderColor = Color.Orange;
        bool _checked;
        public float BorderWidth {
            get { return borderWidth; }
            set {
                borderWidth = value;
                Invalidate();
            }
        }
        public Color BorderColor {
            get { return borderColor; }
            set {
                borderColor = value;
                Invalidate();
            }
        }
        public ButtonX() {
            BorderWidth = 4;
        }
        public bool Checked {
            get { return _checked; }
            set { 
                _checked = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs pevent) {
            base.OnPaint(pevent);
            if (Checked) {
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                for (float f = BorderWidth; f >= 0.01f; f -= 1f)
                {
                    using (Pen pen = new Pen(Color.FromArgb((int)(100 - 100 * f * f / (BorderWidth * BorderWidth)), borderColor), f))
                    {
                        pen.LineJoin = LineJoin.Round;
                        pen.Alignment = PenAlignment.Center;
                        pevent.Graphics.DrawPath(pen, border);
                    }
                }
            }
        }
        private void UpdateBorder() {
            border = new GraphicsPath();
            RectangleF rect = new RectangleF{Width = radius * 2, Height = radius * 2, X = BorderWidth/2, Y = BorderWidth/2};
            border.AddArc(rect, 180, 90);
            rect.X = ClientSize.Width - BorderWidth/2 - radius * 2 - 0.5f;            
            border.AddArc(rect, 270, 90);
            rect.Y = ClientSize.Height - BorderWidth/2 - radius * 2 - 0.5f;
            border.AddArc(rect, 0, 90);
            rect.X = BorderWidth / 2;
            border.AddArc(rect, 90, 90);
            border.CloseAllFigures();
        }
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            UpdateBorder();
        }
    }
