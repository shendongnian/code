    private float GetJointDistance(Joint handR, Joint handL)
    {
        Skeleton s = new Skeleton(); 
        Joint handRight = s.Joints[JointType.HandRight];
        Joint handLeft = s.Joints[JointType.HandLeft]; 
        if (handRight.TrackingState == JointTrackingState.Tracked &&
        handLeft.TrackingState == JointTrackingState.Tracked)
        {
            this.GetJointDistance(handRight, handLeft);
        }
        return xyz;     // xyz must be a float
    }
