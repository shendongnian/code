    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int lineHeight = 0;
        if (textBox1.Lines.Count() > 1)
        {
            Point p1 = textBox1.GetPositionFromCharIndex(textBox1.GetFirstCharIndexFromLine(0));
            Point p2 = textBox1.GetPositionFromCharIndex(textBox1.GetFirstCharIndexFromLine(1));
            lineHeight = Math.Abs(p1.Y - p2.Y);
        }
    
        int lineIndex = textBox1.GetLineFromCharIndex(textBox1.SelectionStart);
        flowLayoutPanel1.AutoScrollPosition = new Point(0, lineIndex * lineHeight);
    }
