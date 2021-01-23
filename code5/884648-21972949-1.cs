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
        }
        using (DrawingContext dc = this.drawingGroup.Open())
        {
                // Draw a transparent background to set the render size
            dc.DrawRectangle(Brushes.Black, null, new Rect(160, 0.0, RenderWidth, RenderHeight));
            RenderClippedEdges(skel, dc);            
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
            
            ...
        }
    }
