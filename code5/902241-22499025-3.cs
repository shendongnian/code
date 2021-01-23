        private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            bool haveSkeletons = false
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (null != skeletonFrame)
                {
                    if ((null == mySkeletons) || (mySkeletons.Length != skeletonFrame.SkeletonArrayLength))
                    {
                        mySkeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    }
                    skeletonFrame.CopySkeletonDataTo(mySkeletons);
                    haveSkeletons = true;
                }
            }
