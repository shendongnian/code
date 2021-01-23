    public Font GetAdjustedFont(Graphics GraphicRef, string GraphicString, Font OriginalFont, int ContainerWidth, int MaxFontSize, int MinFontSize, bool SmallestOnFail)
    {
       // We utilize MeasureString which we get via a control instance           
       for (int AdjustedSize = MaxFontSize; AdjustedSize >= MinFontSize; AdjustedSize--)
       {
          Font TestFont = new Font(OriginalFont.Name, AdjustedSize, OriginalFont.Style);
    
          // Test the string with the new size
          SizeF AdjustedSizeNew = GraphicRef.MeasureString(GraphicString, TestFont);
    
          if (ContainerWidth > Convert.ToInt32(AdjustedSizeNew.Width))
          {
           // Good font, return it
             return TestFont;
          }
       }
    
       // If you get here there was no fontsize that worked
       // return MinimumSize or Original?
       if (SmallestOnFail)
       {
          return new Font(OriginalFont.Name,MinFontSize,OriginalFont.Style);
       }
       else
       {
          return OriginalFont;
       }
    }
