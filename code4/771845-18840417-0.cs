    using (Graphics graphics = Graphics.FromImage(buffer))
    {
        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        TextRenderer.DrawText(graphics, "Hello World", this.Font, this.ClientRectangle, Color.Black);
    }
