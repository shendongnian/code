    private void panel2_Paint(object sender, PaintEventArgs e)
    {
      string fullText = "Text;1/2' LTA";
      StringFormat strgfmt = StringFormat.GenericTypographic;
      Font font = new Font("Times", 60f, FontStyle.Regular);
      float x = 0f;
      using (SolidBrush brush = new SolidBrush(Color.FromArgb(127, 0, 127, 127)))
            for (int i = 0; i < fullText.Length; i++)
            {
                string text = fullText.Substring(i, 1);
                SizeF sf = e.Graphics.MeasureString(text, font, 9999, strgfmt );
                e.Graphics.FillRectangle(brush, new RectangleF(new PointF(x, 0f), sf));
                e.Graphics.DrawString(text, font, Brushes.Black, x, 0, strgfmt );
                x += sf.Width + 1;
                //if (i < fullText.Length - 1) doKerning(fullText.Substring(i, 2), ref x);
            }
    }
    void doKerning(string c12, ref float x)
    {
        if (smallKerningTable.ContainsKey(c12)) x -= smallKerningTable[c12];
    }
    Dictionary<string, float> smallKerningTable = new Dictionary<string, float>();
    void initKerningTable()
    {
        smallKerningTable.Add("Te", 7f);
        smallKerningTable.Add("LT", 8f);
        smallKerningTable.Add("TA", 11f);
        //..
    }
