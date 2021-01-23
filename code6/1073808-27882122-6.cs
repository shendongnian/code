    myPath.Loaded +=
        (o, e) =>
        {
            var myPointAnimation = new PointAnimation
            {
                Duration = TimeSpan.FromSeconds(TimeInterval),
                From = new Point(...),
                To = new Point(...)
            };
            MyAnimatedEllipseGeometry.BeginAnimation(
                EllipseGeometry.CenterProperty, myPointAnimation);
        };
