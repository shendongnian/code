    foreach(KinectSensor s in connectedSensors)
    {
       Tracker tracker = new Tracker(s, sensors);
       s.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
       s.Start();
    }
    while (Char.ToLowerInvariant(Console.ReadKey().KeyChar) != 'q') { }
    foreach(KinectSensor s in connectedSensors)
    {
       s.Stop();
    }
