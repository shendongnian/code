        public int TextWidth(string text)
        {
            TextBlock t = new TextBlock();
            t.Text = text;
            //Height and Width are depending on font settings
            //t.FontFaimily=...
            //t.FontSize=...
            //etc.
            return (int)Math.Ceiling(t.ActualWidth);
        }
