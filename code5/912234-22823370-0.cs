    int trackingID;
    skeletonTracked = new Skeleton();
    bool first = true;
    Skeleton skeleton;
    Skeleton[] skeletons = new Skeleton[6];
    
    ...
    public void AllFramesReady(object sender, AllFramesReadyEventArgs e)
    {
        using (SkeletonFrame sFrame = e.OpenSkeletonFrame())
        {
            sFrame.CopySkeletonDataTo(skeletons);
            skeleton = (from s in skeletons where s.TrackingState == SkeletonTrackingState.Tracked select s).FirstOrDefault();
            if (skeleton == null)
                return;
            if (skeleton.TrackingState == SkeletonTrackingState.Tracked)
            {
                if (first)
                {
                    skeletonTracked = skeleton;
                    trackingId = skeleton.TrackingID;
                    ...
                    first = false;
                }
                if (skeleton.TrackingID == trackingId)
                {
                    ...
                }
            }
        }
