    private void Draw()
    {
        using (Graphics g = this.CreateGraphics())
        {
            g.Clear(Color.Black);
            foreach (Snake_part part in parts)
                g.FillRectangle(Brushes.White, part.Rect);
        }
    }
