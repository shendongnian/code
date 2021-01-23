        using (Graphics g = CreateGraphics())
        {
            SizeF size = g.MeasureString(textBox1.Text, textBox1.Font);
            int linesCount = (int)(size.Height / textBox1.Font.GetHeight());
        }
