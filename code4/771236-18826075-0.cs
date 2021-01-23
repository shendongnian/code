    public static int GetContentHeight(string content, Control contentHolder, Font contentFont)
    {     
		Font font = (contentFont != null) ? contentFont : contentHolder.Font;
		Size sz = new Size(contentHolder.Width, int.MaxValue);
		int padding = 3;
		int borders = contentHolder.Height - contentHolder.ClientSize.Height;
		TextFormatFlags flags = TextFormatFlags.WordBreak;
		sz = TextRenderer.MeasureText(content, contentHolder.Font, sz, flags);
		int cHeight = sz.Height + borders + padding;
		return cHeight;				
    }
