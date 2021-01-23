        private void viewModel(Point3DCollection points)
        {
            DirectionalLight DirLight1 = new DirectionalLight();
            DirLight1.Color = Colors.White;
            DirLight1.Direction = new Vector3D(1, 1, 1);
            PerspectiveCamera Camera1 = new PerspectiveCamera();
            Camera1.FarPlaneDistance = 8000;
            //Camera1.NearPlaneDistance = 100; //close object will not be displayed with this option
            Camera1.FieldOfView = 10;   
            //Camera1.Position = new Point3D(0, 0, 1);
            //Camera1.LookDirection = new Vector3D(-1, -1, -1);
            Camera1.Position = new Point3D(0, 0, 10);
            Camera1.LookDirection = new Point3D(0, 0, 0) - Camera1.Position; //focus camera on real center of your model (0,0,0) in this case
            Camera1.UpDirection = new Vector3D(0, 1, 0);
            //you can use constructor to create Camera instead of assigning its properties like:
            //PerspectiveCamera Camera1 = new PerspectiveCamera(new Point3D(0,0,10), new Vector3D(0,0,-1), new Vector3D(0,1,0), 10);
            bool combinedvertices = true;
            TriangleModel Triatomesh = new TriangleModel();
            MeshGeometry3D tmesh = new MeshGeometry3D();
            GeometryModel3D msheet = new GeometryModel3D();
            Model3DGroup modelGroup = new Model3DGroup();
            ModelVisual3D modelsVisual = new ModelVisual3D();
            Viewport3D myViewport = new Viewport3D();
            for (int i = 0; i < points.Count; i += 3)
            {
                Triatomesh.addTriangleToMesh(points[i + 2], points[i + 1], points[i], tmesh, combinedvertices);                
                //I did swap order of vertexes you may try both options with your model               
            }
            msheet.Geometry = tmesh;
            msheet.Material = new DiffuseMaterial(new SolidColorBrush(Colors.White));
            //you can use constructor to create GeometryModel3D instead of assigning its properties like:
            //msheet = new GeometryModel3D(tmesh, new DiffuseMaterial(new SolidColorBrush(Colors.White)));             
            
            modelGroup.Children.Add(msheet);
            //use AMbientLIght instead of directional
            modelGroup.Children.Add(new AmbientLight(Colors.White));
            
            modelsVisual.Content =  modelGroup;
            myViewport.IsHitTestVisible = false;
            myViewport.Camera = Camera1;
           
            myViewport.Children.Add(modelsVisual);
           
            canvas1.Children.Add(myViewport);
            myViewport.Height = canvas1.Height;
            myViewport.Width = canvas1.Width;
            Canvas.SetTop(myViewport, 0);
            Canvas.SetLeft(myViewport, 0);
        }
