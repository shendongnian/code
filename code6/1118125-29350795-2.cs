        int HowManyChars(Font font, string text, Rectangle r)
        {
            int i = 0;
            for (; i < text.Length; i++)
            {
                string str = text.Substring(0, i);
                var size = TextRenderer.MeasureText(str, font, 
    new Size(r.Width, 0), TextFormatFlags.WordBreak);
    
                
                if (size.Height > r.Height)
                    break;
        
            }
            return i;
        }
