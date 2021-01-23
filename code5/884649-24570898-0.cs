        int skeletonId = 0;
        int trackId = 0;
        void myKinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = null;
            using (SkeletonFrame frame = e.OpenSkeletonFrame())
            {
                if (frame != null)
                {
                    skeletons = new Skeleton[frame.SkeletonArrayLength];
                    frame.CopySkeletonDataTo(skeletons);
                }
            }
            if (skeletons == null) return;
            
            //variable for count of null ID
            int skeletonsNull = 0;
            //counting...
            foreach (Skeleton skeletonText in skeletons)
            {
                if (skeletonText.TrackingId == 0)
                {
                    skeletonsNull++;
                }
                else
                {
                    skeletonId = skeletonText.TrackingId;
                }
            }
            
            if (skeletonsNull == 5)
            {
                trackId = skeletonId;
            }
            foreach (Skeleton skeleton in skeletons)
            {
                if (skeleton.TrackingId == trackId)
                {
                 //do something   
                }
