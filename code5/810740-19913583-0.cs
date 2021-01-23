    public class XCheckBox : CheckBox
    {        
        public XCheckBox()
        {            
            SetStyle(ControlStyles.Opaque, false);
            ReadOnlyCheckedColor = Color.Green;
            ReadOnlyUncheckedColor = Color.Gray;
        }        
        public bool ReadOnly { get; set; }
        public bool AlwaysShowCheck { get; set; }
        public Color ReadOnlyCheckedColor { get; set; }
        public Color ReadOnlyUncheckedColor { get; set; }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (ReadOnly)
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                pevent.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                if (AlwaysShowCheck || Checked)
                {
                    RenderCheck(pevent.Graphics);
                }
                RenderText(pevent.Graphics);                
            }
            else base.OnPaint(pevent);                            
        }
        private void RenderCheck(Graphics g)
        {
            float fontScale = Font.Size / 8.25f;   
            Size glyphSize = CheckBoxRenderer.GetGlyphSize(g, System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);            
            glyphSize.Width = (int) (glyphSize.Width * fontScale);
            glyphSize.Height = (int)(glyphSize.Height * fontScale);            
            string checkAlign = CheckAlign.ToString();
            using (GraphicsPath gp = new GraphicsPath())
            using (Pen pen = new Pen(Checked ? ReadOnlyCheckedColor : ReadOnlyUncheckedColor, 1.5f)
            {
                LineJoin = LineJoin.Round,
                EndCap = LineCap.Round,
                StartCap = LineCap.Round
            })
            {
                gp.AddLine(new Point(3, 7), new Point(5, 10));
                gp.AddLine(new Point(5, 10), new Point(8, 3));
                float dx = checkAlign.EndsWith("Right") ? Math.Max(-4*fontScale, ClientSize.Width - glyphSize.Width - 4 * fontScale) :
                         checkAlign.EndsWith("Center") ? Math.Max(-4*fontScale, (ClientSize.Width - glyphSize.Width) / 2 - 4 * fontScale) : -4;
                float dy = checkAlign.StartsWith("Bottom") ? Math.Max(-4*fontScale, ClientSize.Height - glyphSize.Height - 4*fontScale) :
                         checkAlign.StartsWith("Middle") ? Math.Max(-4*fontScale, (ClientSize.Height - glyphSize.Height) / 2 - 4*fontScale) : 0;
                           
                g.TranslateTransform(dx, dy);
                g.ScaleTransform(1.5f*fontScale, 1.5f*fontScale);
                g.DrawPath(pen, gp);
                g.ResetTransform();                
            }
        }
        private void RenderText(Graphics g)
        {
            Size glyphSize = CheckBoxRenderer.GetGlyphSize(g, System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);
            float fontScale = Font.Size / 8.25f;
            glyphSize.Width = (int)(glyphSize.Width * fontScale);
            glyphSize.Height = (int)(glyphSize.Height * fontScale);
            string checkAlign = CheckAlign.ToString();
            using (StringFormat sf = new StringFormat())
            {
                string alignment = TextAlign.ToString();
                sf.LineAlignment = alignment.StartsWith("Top") ? StringAlignment.Near :
                                   alignment.StartsWith("Middle") ? StringAlignment.Center : StringAlignment.Far;
                sf.Alignment = alignment.EndsWith("Left") ? StringAlignment.Near :
                               alignment.EndsWith("Center") ? StringAlignment.Center : StringAlignment.Far;
                sf.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.NoClip;
                Rectangle textRectangle = ClientRectangle;
                if (checkAlign.EndsWith("Left"))
                {
                    textRectangle.Width -= glyphSize.Width;
                    textRectangle.Offset(glyphSize.Width, 0);
                }
                else if (checkAlign.EndsWith("Right"))
                {
                    textRectangle.Width -= glyphSize.Width;
                    textRectangle.X = 0;
                }
                g.DrawString(Text, Font, new SolidBrush(ForeColor), textRectangle, sf);
            }
        }        
        bool suppressCheckedChanged;
        protected override void OnClick(EventArgs e)
        {
            if (ReadOnly) {
                suppressCheckedChanged = true;
                Checked = !Checked;
                suppressCheckedChanged = false;
            }
            base.OnClick(e);
        }
        protected override void OnCheckedChanged(EventArgs e)
        {
            if (suppressCheckedChanged) return;
            base.OnCheckedChanged(e);
        }        
    }
