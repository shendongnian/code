    using System.IO;
    StreamWriter writer = new StreamWriter(@path);
    int frames = 0;
    ...
    void AllFramesReady(object sender, AllFramesReadyEventArgs e)
    {
        frames++;
        using (SkeletonFrame sFrame = e.OpenSkeletonFrameData())
        {
            if (sFrame == null)
                return;
            skeletonFrame.CopySkeletonDataTo(skeletons);
            Skeleton skeleton = (from s in skeletons
                                    where s.TrackingState == SkeletonTrackingState.Tracked
                                    select s);
            if (skeleton == null)
                return;
            if (skeleton.TrackingState == SkeletonTrackingState.Tracked)
            {
                foreach (Joint joint in skeleton.Joints)
                {
                    writer.Write(joint.Position.X + "," + joint.Position.Y + "," joint.Position.Z + ",");
                }
                writer.Write(Environment.NewLine);
            }
        }
    }
