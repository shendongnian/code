    public void SetFonts(SvgElement parent)
    {
        try
        {
            SvgText svgText = (SvgText)parent;
            svgText.Font = new System.Drawing.Font("Arial", svgText.FontSize.Value);
        }
        catch
        {
        }
        if(parent.HasChildren())
        {
            foreach(SvgElement child in parent.Children)
            {
                SetFonts(child);
            }
        }
    }
