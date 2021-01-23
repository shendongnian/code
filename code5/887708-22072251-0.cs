    public static Size MeasureText(string Text, Font Font)
            {
                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.Top
                  | TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix;
    
                StringFormat strFormat = (StringFormat)StringFormat.GenericDefault.Clone();
                strFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
    
                Size szProposed = new Size(int.MaxValue, int.MaxValue);
    
                Size sz1 = TextRenderer.MeasureText(".", Font, szProposed, flags);
                Size sz2 = TextRenderer.MeasureText(Text + ".", Font, szProposed, flags);
    
                if (Font.Bold)
                    sz1.Width -= 1;
    
                return new Size(sz2.Width - sz1.Width, sz2.Height);
            }
