        protected override void OnPaint(PaintEventArgs e)
        {
            Image bmp = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            SolidBrush brushBase = new SolidBrush(this.BaseColor); //custom property
            SolidBrush brushBack = new SolidBrush(this.BackColor);
            SolidBrush brushFore = new SolidBrush(this.ForeColor);
            //base ellipse
            g.FillEllipse(brushBase, GetRectangle(0));
            //fallowing code block creates circular gradient
            int i = 0;
            float endAngle = 360f * this.Value / 100 - 90f;
            float sweepAngle = 360f / _gradientBrushList.Count;
            for (float startAngle = -90f; startAngle < endAngle; startAngle += sweepAngle)
            {
                if (i < _gradientBrushList.Count)
                {
                    g.DrawPie(_gradientPenList[i++], GetRectangle(0), startAngle, sweepAngle);
                    g.FillPie(_gradientBrushList[i++], GetRectangle(0), startAngle, sweepAngle);
                }
            }
            //back ellipse
            g.FillEllipse(brushBack, GetRectangle(this.Thickness));
            //draw value string in center of p-bar
            string value = this.Value.ToString();
            float fontSize = (float)(Math.Min(this.Width - this.Thickness * 2, this.Height - this.Thickness * 2) / 2);
            Font font = new Font("Calibri", (fontSize > 0 ? fontSize : 1), FontStyle.Bold, GraphicsUnit.Pixel);
            SizeF strLen = g.MeasureString(value, font);
            Point strLoc = new Point((int)((this.Width / 2) - (strLen.Width / 2)), (int)((this.Height / 2) - (strLen.Height / 2)));
            g.DrawString(value, font, brushFore, strLoc);
            e.Graphics.DrawImage(bmp, Point.Empty);
        }
        private Rectangle GetRectangle(int offset)
        {
            return new Rectangle(offset, offset, this.Width - offset * 2, this.Height - offset * 2);
        }
        private List<SolidBrush> _gradientBrushList = new List<SolidBrush>();
        private List<Pen> _gradientPenList = new List<Pen>();
        private void CreateGradientBrushList(ref List<Color> _gradientColorList)
        {
            List<Color> gradientColorList = new List<Color>();
            foreach (Color color in _gradientColorList)
                gradientColorList.Add(color);
            for (int subdivideCount = 0; subdivideCount <= 3; subdivideCount++) //Smoothness
            {
                int i = 0;
                int gradientColorListCount = gradientColorList.Count - 1;
                while (i < gradientColorListCount)
                {
                    gradientColorList.Insert(i + 1, GetMiddleColor(gradientColorList[i], gradientColorList[i + 1]));
                    i += 2;
                    gradientColorListCount++;
                }
            }
            foreach (Color color in gradientColorList)
            {
                _gradientBrushList.Add(new SolidBrush(color));
                _gradientPenList.Add(new Pen(color));
            }
        }
