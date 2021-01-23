    Canvas c = new Canvas();
    double oPrintWidth=100;
    double ratio = .89;
    c.Width = oPrintWidth * 2.54;
    c.Height = c.Width * ratio;
    c.Background = new ImageBrush((ImageSource)FindResource("TestImage")) { Stretch = Stretch.UniformToFill };
            
    // Define the path to clip
    string newPath = "M 64,64 L 64,128 128,128, 128,64 Z";
    c.Clip = Geometry.Parse(newPath);
    Rect bounds = c.Clip.Bounds;
    double scaleX = c.Width / (bounds.Right - bounds.Left);
    double scaleY = c.Height / (bounds.Bottom - bounds.Top);
    TransformGroup group = new TransformGroup();
    TranslateTransform move = new TranslateTransform(-bounds.Left, -bounds.Top);
    ScaleTransform scale = new ScaleTransform(scaleX, scaleY);
    group.Children.Add(move);
    group.Children.Add(scale);
    c.RenderTransform = group;
    MyBorder.Child = c;
