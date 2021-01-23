        public CustomComboBox()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Win32.WM_MOUSEFIRST || m.Msg == Win32.WM_MOUSELEAVE || m.Msg == Win32.WM_MOUSEHOVER) //0x0200, 0x02A3, 0x02A1
            {
                m.Result = (IntPtr)1;
                return;
            }
            base.WndProc(ref m);
            if (m.Msg == Win32.WM_PAINT)
            {
                IntPtr hDC = Win32.GetWindowDC(m.HWnd);
                Graphics g = Graphics.FromHdc(hDC);
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                if (Text.Length == 0)
                {
                    StringFormat stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Near
                    };
                    g.DrawString("Water Marks", Font, new SolidBrush(Color.FromArgb(51, 51, 51)), (Bounds.Width - 2), FontHeight + 2, stringFormat);
                }
                Pen border = new Pen(ui_BorderLineColor, 1);
                g.DrawRectangle(border, 0, 0, this.Width - 1, this.Height - 1);
                g.Dispose();
                Win32.ReleaseDC(m.HWnd, hDC);
            }
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            DropDownStyle = ComboBoxStyle.DropDownList; //Works only in DropDownList          
        }
