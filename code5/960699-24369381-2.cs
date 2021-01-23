    int id1 = 0, id2 = 0;
    ... 
    if (skeletons.Length != 0)
    {
        foreach (Skeleton skel in skeletons)
        {
             if (skel.TrackingState == SkeletonTrackingState.Tracked)
             {
                    if (skel.TrackingID == id1)
                        this.tracked(skel);
                    else if (skel.TrackingID == id2)
                        this.trackedLeft(skel);
                    else
                    {
                         if (id1 != 0 && id2 == 0)
                             id2 = skel.TrackingID;
                         else if (id2 != 0 && id1 == 0)
                             id1 = skel.TrackingID;
                    }
             }
         }
      }
    
    
