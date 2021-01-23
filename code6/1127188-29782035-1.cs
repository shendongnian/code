    private void DrawBone(Joint first, Joint second)
    {
        Line line = new Line();
        line.Stroke = Brushes.LightSteelBlue;
    
        line.X1 = first.Position.X;
        line.X2 = second.Position.X;
        line.Y1 = first.Position.Y;
        line.Y2 = second.Position.Y;
        
        line.StrokeThickness = 2;
        myCanvas.Children.Add(line);
    }
