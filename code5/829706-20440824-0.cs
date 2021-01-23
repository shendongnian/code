    private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Point btn1Point = btn1.TransformToAncestor(this).Transform(new Point(0, 0));
            Point btn2Point = btn2.TransformToAncestor(this).Transform(new Point(0, 0));
            Line l = new Line();
            l.Stroke = new SolidColorBrush(Colors.Black);
            l.StrokeThickness = 2.0;
            l.X1 = btn1Point.X + btn1.ActualWidth;
            l.X2 = btn2Point.X;
            l.Y1 = btn1Point.Y + btn1.ActualHeight/2;
            l.Y2 = btn2Point.Y + btn2.ActualHeight / 2;
            myCanvas.Children.Add(l);
        }
