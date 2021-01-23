        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            float vlblControlWidth;
            float vlblControlHeight;
            float vlblTransformX;
            float vlblTransformY;
        
            Color controlBackColor = BackColor;
            Pen labelBorderPen;
            SolidBrush labelBackColorBrush;
        
            if (_transparentBG)
            {
                labelBorderPen = new Pen(Color.Empty, 0);
                labelBackColorBrush = new SolidBrush(Color.Empty);
                }
                else
                {
                   labelBorderPen = new Pen(controlBackColor, 0);
                  labelBackColorBrush = new SolidBrush(controlBackColor);
              }
             
            SolidBrush labelForeColorBrush = new SolidBrush(base.ForeColor);
            base.OnPaint(e);
            vlblControlWidth = this.Size.Width;
            vlblControlHeight = this.Size.Height;
            e.Graphics.DrawRectangle(labelBorderPen, 0, 0, 
                                     vlblControlWidth, vlblControlHeight);
            e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, 
                                     vlblControlWidth, vlblControlHeight);
            e.Graphics.TextRenderingHint = this._renderMode;
            e.Graphics.SmoothingMode = 
                       System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
            if (this.TextDrawMode == DrawMode.BottomUp)
            {
                vlblTransformX = 0;
                vlblTransformY = vlblControlHeight;
                e.Graphics.TranslateTransform(vlblTransformX, vlblTransformY);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(labelText, Font, labelForeColorBrush, 0, 0);
            }
            else
            {
                     vlblTransformX = vlblControlWidth;
                     vlblTransformY = vlblControlHeight;
                     e.Graphics.TranslateTransform(vlblControlWidth, 0);
                     e.Graphics.RotateTransform(90);
                     e.Graphics.DrawString(labelText, Font, labelForeColorBrush, 0,
                                         0,StringFormat.GenericTypographic);
                }            
            }
         
            SetStyle(System.Windows.Forms.ControlStyles.Opaque, true);
         
      }
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
            return cp;
        }
    }
