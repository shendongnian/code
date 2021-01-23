    /// <summary>
    /// Calculate Render Width
    /// </summary>
    /// <param name="str"></param>
    /// <param name="fontFamily"></param>
    /// <param name="fontSize"></param>
    /// <returns></returns>
    public static float GetWidthOfString(string str, string fontFamily, int fontSize)
    {
    	var font = new System.Drawing.Font(fontFamily, fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
    	var size = TextRenderer.MeasureText(str, font); // GDI              
    
    	return size.Width;
    }
