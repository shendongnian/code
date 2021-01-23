    public void ClearBackbuffer()
    {
        Graphics g = Graphics.FromImage(_reference_to_your_backbuffer_);
        g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
        SolidBrush sb = new SolidBrush(Color.FromArgb(0x00, 0x00, 0x00, 0x00));
        g.FillRectangle(sb, this.ClientRectangle);
        sb.Dispose();
        g.Dispose();
    }
