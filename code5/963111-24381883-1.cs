        private void Render_click(object sender, RoutedEventArgs e)
        {
            PerspectiveCamera came = new PerspectiveCamera();
            came.Position = new Point3D(0, 0, 4);
            vp.Camera = came;
            ModelVisual3D light = new ModelVisual3D();
            AmbientLight ambLight = new AmbientLight(Colors.White);
            light.Content = ambLight;
            vp.Children.Add(light);
            Viewport2DVisual3D v2d = new Viewport2DVisual3D();
            MeshGeometry3D geom3d = new MeshGeometry3D();
            geom3d.Positions = new Point3DCollection() { new Point3D(-1, 1, 0), new Point3D(-1, -1, 0), new Point3D(1, -1, 0), new Point3D(1, 1, 0) };
            geom3d.TextureCoordinates = new PointCollection() { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0) };
            geom3d.TriangleIndices = new Int32Collection() { 0, 1, 2, 0, 2, 3 };
            v2d.Geometry = geom3d;
            DiffuseMaterial mat = new DiffuseMaterial(new SolidColorBrush(Colors.Black));
            Viewport2DVisual3D.SetIsVisualHostMaterial(mat, true);
            v2d.Material = mat;
            v2d.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 45));
            Image img = new Image();
            BitmapImage bmpRend = new BitmapImage();
            bmpRend.BeginInit();
            bmpRend.UriSource = new Uri(@"image-1.jpg", UriKind.Relative);
            bmpRend.EndInit();
            img.Source = bmpRend;
            img.Width = 200;
            img.Height = 200;
          
            img.Source = bmpRend;
            v2d.Visual = img;
            vp.Children.Add(v2d);
            int wd = 500; 
            int ht = 500; 
            vp.Width = wd;
            vp.Height = ht;
            vp.Measure(new Size(wd, ht));
            vp.Arrange(new Rect(0, 0, wd, ht));
        
        }
