        public static void setRtf(ref RichTextBox rtfBox, string text, bool fromMe = false)
        {
            Paragraph p = new Paragraph();
            p.FontFamily = rtfBox.FontFamily;
            p.TextAlignment = fromMe ? TextAlignment.Left : TextAlignment.Right;
            Run pTxt = new Run();
            pTxt.Text = text;
            p.Inlines.Add(pTxt);
            rtfBox.Blocks.Add(p);
        }
