        MeshGeometry3D mg3 = (MeshGeometry3D)modelScull.Geometry;
        for(int index=0;index<mg3.TriangleIndices; index+=3)
        {
            ScreenSpaceLines3D wireframe = new ScreenSpaceLines3D();
            wireframe.Points.Add(mg3.Positions[index]);
            wireframe.Points.Add(mg3.Positions[index+1]);
            wireframe.Points.Add(mg3.Positions[index+2]);
            wireframe.Points.Add(mg3.Positions[index]);
            wireframe.Color = Colors.LightBlue;
            wireframe.Thickness = 1;
            Viewport3D1.Children.Add(wireframe);
        }
