    if (e.Index > -1)
    {
        e.DrawBackground();
    
        SolidBrush bgColourBrush = null;
        SolidBrush fgColourBrush = null;
        ComboBox combo = (ComboBox)sender;
        objPDT.ListCell pdt = (objPDT.ListCell)combo.Items[e.Index];
        try {
            if (e.ForeColor == SystemColors.HighlightText)
            {
                bgColourBrush = new SolidBrush(e.BackColor);
                fgColourBrush = new SolidBrush(e.ForeColor);
            }
            else if (pdt.bgColour == null)
            {
                bgColourBrush = new SolidBrush(Color.Black);
                fgColourBrush = new SolidBrush(Color.White);
            }
            else
            {
                bgColourBrush = pdt.bgColour;
                fgColourBrush = pdt.fgColour;
            }
    
            // background
            e.Graphics.FillRectangle(bgColourBrush, e.Bounds);
            //foreground
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawString(pdt.Name, combo.Font, fgColourBrush, e.Bounds.X, e.Bounds.Y);
        } finally {
            if(bgColorBrush != null) {
                bgColorBrush.Dispose();
            }
            if(fgColorBrush != null) {
                fgColorBrush.Dispose();
            }
        }
    }
