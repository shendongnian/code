    var group = new TransformGroup();
    var trans = new TranslateTransform();
    group.Children.Add(trans);
    var rotate = new RotateTransform();
    group.Children.Add(rotate);
    
    Pointer.RenderTransform = group;
    
    // the rest of the code is fine; only the last line needs fixing:
    
    rotate.BeginAnimation(RotateTransform.AngleProperty, rotateBy);
