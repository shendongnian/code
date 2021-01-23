    private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
    {
        using (SkeletonFrame frame = e.OpenSkeletonFrame())
        {
                if (frame == null)
                        return;
                // resize the skeletons array if needed
                if (skeletons.Length != frame.SkeletonArrayLength)
                        skeletons = new Skeleton[frame.SkeletonArrayLength];
                // get the skeleton data
                frame.CopySkeletonDataTo(skeletons);
                foreach (var skeleton in skeletons)
                {
                        // skip the skeleton if it is not being tracked
                        if (skeleton.TrackingState != SkeletonTrackingState.Tracked)
                                continue;
                        // update the gesture controller
                        gestureController.UpdateAllGestures(skeleton);
                }
        }
    }
