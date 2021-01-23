       for(int i=0; i++i < sensors){
            KinectSensor s = connectedSensors[i];
            Tracker tracker = new Tracker(s, i); //the second parameter here is the one you needed to fix.
            s.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
            s.Start();
            while (Char.ToLowerInvariant(Console.ReadKey().KeyChar) != 'q') { }
            s.Stop();
        }
