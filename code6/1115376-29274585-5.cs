    string ReducedText(Label lbl, string text)
    {
        char ell = (char)0x00002026;
        lbl.Tag = text;
        string redString = text;
        using (Font font = new Font(lbl.Font, FontStyle.Bold))
        using (Graphics G = lbl.CreateGraphics())
        {
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            float elltWidth = TextRenderer.MeasureText(G, ell.ToString(), font).Width;
            float textWidth = TextRenderer.MeasureText(G, redString, font).Width;
            elltWidth += lbl.Padding.Left + lbl.Padding.Right ;
            if (textWidth < lbl.ClientSize.Width) return text;
            SizeF s = SizeF.Empty;
            do
            {
                redString = redString.Substring(0, redString.Length - 1);
                s = TextRenderer.MeasureText(G, redString, font);
                Console.WriteLine(s.Width + "  " + lbl.ClientSize.Width + " " + redString);
            } while (s.Width + elltWidth > lbl.ClientSize.Width);
        }
        return redString + ell;
    }
