    Random r = new Random();
    for (int i = m_text.Length - 1; i >= 0; i--)
    {
    
    	Point pt = new Point((int)((this.ClientSize.Width - e.Graphics.MeasureString(m_text[i], m_font).Width) / 2),
    		(int)(m_scrollingOffset + this.ClientSize.Height - (m_text.Length - i) * m_font.Size));
    
    	// Adds visible lines to path.
    	if ((pt.Y + this.Font.Size > 0) && (pt.Y < this.Height))
    	{
    		path.AddString(m_text[i], m_font.FontFamily, (int)m_font.Style, m_font.Size,
    			pt, StringFormat.GenericTypographic);
    
    		visibleLines++;
    	}
    
    	
        Color c = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
    	Font drawFont = new Font("Arial", 16);	
    	e.Graphics.DrawString( m_text[i], drawFont, new SolidBrush(c), pt);
    }
