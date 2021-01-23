    double zAngle = 45;
    double xAngle = 10;
    Transform3DGroup group = new Transform3DGroup();
    group.Children.Add( new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), xAngle)));
    group.Children.Add( new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), zAngle)));
    foreach (Point3D p in listPoint3)
    {
        Point3D rotatedPoint = group.Transform(p);
    }
