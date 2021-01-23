    StreamReader reader = new StreamReader(@path);
    int frame = -1;
    JointCollection joints;
    ...
    string[] lines = reader.ReadAllLines();
    ...
    
    void AllFramesReady(object sender, AllFramesReadyEventArgs e)
    {
        canvas.Children.Clear();
        string[] coords = lines[frame];
        int jointIndex = 0;
        for (int i = 0; i < coords.Length; i += 3)
        {
            joints[jointIndex].Position.X = int.Parse(coords[i]);
            joints[jointIndex].Position.Y = int.Parse(coords[i + 1]);
            joints[jointIndex].Position.X = int.Parse(coords[i + 2]);
            jointIndex++;
        }
        DepthImageFrame depthFrame = e.OpenDepthImageFrame();
        canvas.Children.Add(GetBodySegment(joints, brush, new JointType[] { JointType.HipCenter, JointType.Spine, JointType.ShoulderCenter, JointType.Head }, depthFrame, canvas));
		canvas.Children.Add(GetBodySegment(joints, brush, new JointType[] { JointType.ShoulderCenter, JointType.ShoulderLeft, JointType.ElbowLeft, JointType.WristLeft, JointType.HandLeft }, depthFrame, canvas));
        canvas.Children.Add(GetBodySegment(joints, brush, new JointType[] { JointType.ShoulderCenter, JointType.ShoulderRight, JointType.ElbowRight, JointType.WristRight, JointType.HandRight }, depthFrame, canvas));
        canvas.Children.Add(GetBodySegment(joints, brush, new JointType[] { JointType.HipCenter, JointType.HipLeft, JointType.KneeLeft, JointType.AnkleLeft, JointType.FootLeft }, depthFrame, canvas));
        canvas.Children.Add(GetBodySegment(joints, brush, new JointType[] { JointType.HipCenter, JointType.HipRight, JointType.KneeRight, JointType.AnkleRight, JointType.FootRight }, depthFrame, canvas));
        depthFrame.Dispose();
       
        frame++;
    }
    Point GetDisplayPosition(Joint joint, DepthImageFrame depthFrame, Canvas skeleton)
    {
        float depthX, depthY;
        KinectSensor sensor = KinectSensor.KinectSensors[0];
        DepthImageFormat depthImageFormat = sensor.DepthStream.Format;
        DepthImagePoint depthPoint = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(joint.Position, depthImageFormat);
        depthX = depthPoint.X;
        depthY = depthPoint.Y;
        depthX = Math.Max(0, Math.Min(depthX * 320, 320));
        depthY = Math.Max(0, Math.Min(depthY * 240, 240));
        int colorX, colorY;
        ColorImagePoint colorPoint = sensor.CoordinateMapper.MapDepthPointToColorPoint(depthImageFormat, depthPoint, ColorImageFormat.RgbResolution640x480Fps30);
        colorX = colorPoint.X;
        colorY = colorPoint.Y;
        return new System.Windows.Point((int)(skeleton.Width * colorX / 640.0), (int)(skeleton.Height * colorY / 480));
    }
    Polyline GetBodySegment(Joint[] joints, Brush brush, JointType[] ids, DepthImageFrame depthFrame, Canvas canvas)
    {
        PointCollection points = new PointCollection(ids.Length);
        for (int i = 0; i < ids.Length; ++i)
        {
            points.Add(GetDisplayPosition(joints[i], depthFrame, canvas));
        }
        Polyline polyline = new Polyline();
        polyline.Points = points;
        polyline.Stroke = brush;
        polyline.StrokeThickness = 5;
        return polyline;
    }
