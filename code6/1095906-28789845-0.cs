               //create PointGeometryModel3D object
            PointGeometryModel3D pgm = new PointGeometryModel3D();
            //create positions
            pgm.Geometry.Positions = new HelixToolkit.Wpf.SharpDX.Core.Vector3Collection();
            
            pgm.Geometry.Positions.AddRange(
                new SharpDX.Vector3[]
                {   new SharpDX.Vector3(0,1,2), 
                    new SharpDX.Vector3(1,2,3), 
                    new SharpDX.Vector3(3,2,3), 
                });
            //create colors
            pgm.Geometry.Colors = new HelixToolkit.Wpf.SharpDX.Core.Color4Collection();
            pgm.Geometry.Colors.AddRange(
                new SharpDX.Color4[]
                {   
                    new SharpDX.Color4(1f,0,0,1), 
                    new SharpDX.Color4(0,1f,0,1), 
                    new SharpDX.Color4(0,0,1f,1) 
                });
            //create indices
            pgm.Geometry.Indices = new HelixToolkit.Wpf.SharpDX.Core.IntCollection();
            pgm.Geometry.Indices.AddRange(
                new int[]
                {   
                    0,
                    1,
                    2,
                });
 
