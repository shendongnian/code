    else
    {
        e.DrawBackground();
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        TextRenderer.DrawText(e.Graphics, ...);
    }
