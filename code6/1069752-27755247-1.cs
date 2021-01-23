    Polyline[] linije = new Polyline[10];     
    linije[0] = new Polyline();  // Create the Polyline object!!!
    linije[0].Stroke = System.Windows.Media.Brushes.Black;           
    linije[0].StrokeThickness = 1;        
    linije[0].Points = poli.Points;          
    canvas1.Children.Add(linije[0]);
