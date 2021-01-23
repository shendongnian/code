    private void DrawPointsOnRectangle(Graphics g, int numberOfPoints)
    {
        var brush = new SolidBrush(Color.DarkGreen);
        const int rectanglePenWidth = 2;
        //North & South
        int spacing = mRect.Width / (numberOfPoints - 1);
            
        for (int x = 0; x < numberOfPoints; x++)
        {
            g.FillEllipse(brush, mRect.X + (x * spacing) - rectanglePenWidth - 5, mRect.Y - 7, 15, 15);
            g.FillEllipse(brush, mRect.X + (x * spacing) - rectanglePenWidth - 5, mRect.Y - 7 + mRect.Height, 15, 15);    
        }
            
        //East & West
        spacing = mRect.Height/(numberOfPoints - 1);
        for (int y = 0; y < numberOfPoints; y++)
        {
            g.FillEllipse(brush, mRect.X - rectanglePenWidth - 5, mRect.Y - 7 + (y * spacing), 15, 15);
            g.FillEllipse(brush, mRect.X - rectanglePenWidth - 5 + mRect.Width, mRect.Y - 7 + (y * spacing), 15, 15);
        }
    }
