    public static void ColorListBox(List<string> data, DrawItemEventArgs e)
    {
        string strLeft = null;
        string strMid = "---";
        string strRight = null;
        if (e.Index < data.Count)
        {
            if (data[e.Index].Contains(strMid))
            {
                int index = data[e.Index].IndexOf(strMid);
                strLeft = data[e.Index].Substring(0, index);
                strRight = data[e.Index].Substring(index + strMid.Length);
            }
    
            using (Font f = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular))
            {
                float startPos;
                e.Graphics.DrawString(strLeft, f, Brushes.Red, e.Bounds.X, e.Bounds.Y);
                startPos = e.Graphics.MeasureString(strLeft, f).Width;
                e.Graphics.DrawString(strMid, f, Brushes.Black, e.Bounds.X + startPos, e.Bounds.Y);
                startPos = e.Graphics.MeasureString(strLeft + strMid, f).Width;
                e.Graphics.DrawString(strRight, f, Brushes.Green, e.Bounds.X + startPos, e.Bounds.Y);
            }
        }
    }
