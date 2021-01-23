         Image img = new Image();
         
         GeometryDrawing gDrwing = new GeometryDrawing();
         gDrwing.Brush = Brushes.Black;
         LineGeometry lineGeo = new LineGeometry();
         lineGeo.StartPoint = new Point(0, 9);
         lineGeo.EndPoint = new Point(38, 9);
         
         Pen pen = new Pen();
         pen.Brush = Brushes.Black;
         pen.Thickness = 1;
         pen.DashStyle = DashStyles.DashDot;
         gDrwing.Geometry = lineGeo;
         gDrwing.Pen = pen;
         DrawingImage geometryImage = new DrawingImage(gDrwing);
         img.Source = geometryImage;
         Viewbox vb = new Viewbox();
         vb.Child = img;
         comboBox1.Items.Add(vb);
