    public class VideoControl : ReusableUIElement3D
    {
        protected override Model3D CreateElementModel()
        {
            Model3DGroup cubeModel = new Model3DGroup();
            cubeModel.Children.Add(CreateModel());
            return cubeModel;
        }
        private GeometryModel3D CreateModel()
        {
            return new GeometryModel3D
            {
                Geometry = new MeshGeometry3D
                {
                    Positions = new Point3DCollection
                {
                    new Point3D(-100, -100, 0),
                    new Point3D(100, -100, 0),
                    new Point3D(100, 100, 0),
                    new Point3D(-100, 100, 0)
                },
                    TextureCoordinates = new PointCollection
                {
                    new Point(0, 1),
                    new Point(1, 1),
                    new Point(1, 0),
                    new Point(0, 0)
                },
                    TriangleIndices = new Int32Collection
                {
                    0, 1, 2,
                    0, 2, 3
                }
                },
                Material = new DiffuseMaterial(new VisualBrush(new MediaElement
                {
                    Source = new Uri("http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4", UriKind.RelativeOrAbsolute),
                }))
            };
        }
    }
