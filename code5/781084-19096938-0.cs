    double angle = 45;
    RotateTransform3D zrotation = new RotateTransform3D(new AxisAngleRotation3D(
                                      new Vector3D(0, 0, 1), angle));
    foreach (Point3D p in listPoint3)
    {
        Point3D rotatedPoint = zrotation.Transform(p);
    }
   
