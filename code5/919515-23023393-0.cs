    System.Int64 lastSkeletonTime = 0;
    public bool pollSkeleton () 
    {
      if (kinect.getSkeleton().liTimeStamp > lastSkeletonTime) {
        updatedSkeleton = true; 
        newSkeleton = true;
        System.Int64 cur = kinect.getSkeleton().liTimeStamp;
        System.Int64 diff = cur - lastSkeletonTime;
        deltaTime = diff / (float)1000;
        lastSkeletonTime = cur;
        processSkeleton();
      }
      return newSkeleton;
    }
