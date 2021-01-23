    public class SkeletonVectorCollection : Skeleton
    {
        private Dictionary<JointType, BoneVector> _boneVectors = new Dictionary<JointType, BoneVector>();
        public SkeletonVectorCollection(Skeleton input)
        {
            foreach (BoneOrientation orientation in input.BoneOrientations)
            {
                this[orientation.EndJoint] = new BoneVector(input.Joints[orientation.StartJoint], input.Joints[orientation.EndJoint]);   
            }
        }
        public BoneVector this[JointType jointType] 
        {
            get
            {
                return _boneVectors[jointType];
            }
            protected set
            {
                _boneVectors[jointType] = value;
            }
        }
    }
