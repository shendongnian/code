    using System.Windows.Media.Media3D;
    ...
    // Define a 90 degree rotation about Y axis
    var rotation = new AxisAngleRotation(new Vector(0,1,0), 90);
    // Create transformation from our rotation definition
    var transform = new RotateTransform3D(rotation);
    // Rotate a point using the transformation
    var original = new Vector3D(1, 1, 1);
    var rotated = transform.Transform(original);
