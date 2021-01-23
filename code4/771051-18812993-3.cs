        MeshGeometry3D mg3 = (MeshGeometry3D)modelScull.Geometry;
        for(int index=0;index<mg3.TriangleIndices.Count; index+=3)
        {
            ScreenSpaceLines3D wireframe = new ScreenSpaceLines3D();
            wireframe.Points.Add(mg3.Positions[mg3.TriangleIndices[index]]);
            wireframe.Points.Add(mg3.Positions[mg3.TriangleIndices[index+1]]);
            wireframe.Points.Add(mg3.Positions[mg3.TriangleIndices[index+2]]);
            wireframe.Points.Add(mg3.Positions[mg3.TriangleIndices[index]]);
            wireframe.Color = Colors.LightBlue;
            wireframe.Thickness = 1;
            Viewport3D1.Children.Add(wireframe);
        }
