    public static void DrawStringTrim(this SpriteBatch spriteBatch, SpriteFont font, Rectangle rect, string text, Color color)
    {
        // Characters to append to end of text, can be removed.
        string ellipsis = "...";
    
        // Get the width of the text string.
        int size = (int)Math.Ceiling(font.MeasureString(text).X);
    
        // Is text longer than the destination region? If not, simply draw it
        if (size > rect.Width)
        {
            // Account for the length of the "..." (ellipsis) string.
            int es = string.IsNullOrWhiteSpace(ellipsis) ? 0 : (int)Math.Ceiling(font.MeasureString(ellipsis).X);
            for (int i = text.Length - 1; i > 0; i--)
            {
                int c = 1;
    
                // Remove two letters if the preceding character is a space.
                if (char.IsWhiteSpace(text[i - 1]))
                {
                    c = 2;
                    i--;
                }
    
                // Chop off the tail of the string and re-measure the width.
                text = text.Remove(i, c);
                size = (int)Math.Ceiling(font.MeasureString(text).X);
    
                // Text is short enough?
                if (size + es <= rect.Width)
                    break;
            }
    
            // Append the ellipsis to the truncated string.
            text += ellipsis;
        }
    
        // Draw the text
        spriteBatch.DrawString(font, text, new Vector2(rect.X, rect.Y), color);
    }
