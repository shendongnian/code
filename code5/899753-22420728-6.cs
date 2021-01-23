    using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
    {
        SizeF size = g.MeasureString(longestString, 
                         System.Drawing.SystemFonts.DefaultFont);
        gridView.Columns[0].Width = size.Width;
    }
