    public class SkeletonVectorCollection : Dictionary<JointType, BoneVector>
    {
        public SkeletonVectorCollection(Skeleton input)
        {
            foreach (BoneOrientation orientation in input.BoneOrientations)
            {
                this[orientation.EndJoint] = new BoneVector(input.Joints[orientation.StartJoint], input.Joints[orientation.EndJoint]);   
            }
        }
    }
