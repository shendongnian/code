        public class Angles
        {
        public double AngleBetweenTwoVectors(Vector3D vectorA, Vector3D vectorB)
            {
                double dotProduct = 0.0;
                dotProduct = Vector3D.DotProduct(vectorA, vectorB);
    
                return (double)Math.Acos(dotProduct)/Math.PI*180;
            }
        
            public double[] GetVector(Skeleton skeleton)
            {
                Vector3D ShoulderCenter = new Vector3D(skeleton.Joints[JointType.ShoulderCenter].Position.X, skeleton.Joints[JointType.ShoulderCenter].Position.Y, skeleton.Joints[JointType.ShoulderCenter].Position.Z);
                Vector3D RightShoulder = new Vector3D(skeleton.Joints[JointType.ShoulderRight].Position.X, skeleton.Joints[JointType.ShoulderRight].Position.Y, skeleton.Joints[JointType.ShoulderRight].Position.Z);
                Vector3D LeftShoulder = new Vector3D(skeleton.Joints[JointType.ShoulderLeft].Position.X, skeleton.Joints[JointType.ShoulderLeft].Position.Y, skeleton.Joints[JointType.ShoulderLeft].Position.Z);
                Vector3D RightElbow = new Vector3D(skeleton.Joints[JointType.ElbowRight].Position.X, skeleton.Joints[JointType.ElbowRight].Position.Y, skeleton.Joints[JointType.ElbowRight].Position.Z);
                Vector3D LeftElbow = new Vector3D(skeleton.Joints[JointType.ElbowLeft].Position.X, skeleton.Joints[JointType.ElbowLeft].Position.Y, skeleton.Joints[JointType.ElbowLeft].Position.Z);
                Vector3D RightWrist = new Vector3D(skeleton.Joints[JointType.WristRight].Position.X, skeleton.Joints[JointType.WristRight].Position.Y, skeleton.Joints[JointType.WristRight].Position.Z);
                Vector3D LeftWrist = new Vector3D(skeleton.Joints[JointType.WristLeft].Position.X, skeleton.Joints[JointType.WristLeft].Position.Y, skeleton.Joints[JointType.WristLeft].Position.Z);
    
               /* ShoulderCenter.Normalize();
                RightShoulder.Normalize();
                LeftShoulder.Normalize();
                RightElbow.Normalize();
                LeftElbow.Normalize();
                RightWrist.Normalize();
                LeftWrist.Normalize();
    
                if (skeleton.Joints[JointType.ShoulderCenter].TrackingState == JointTrackingState.Tracked) { 
                
                }
                */
    
                double AngleRightElbow = AngleBetweenTwoVectors(RightElbow - RightShoulder, RightElbow - RightWrist);
                double AngleRightShoulder = AngleBetweenTwoVectors(RightShoulder - ShoulderCenter, RightShoulder - RightElbow);
                double AngleLeftElbow = AngleBetweenTwoVectors(LeftElbow - LeftShoulder, LeftElbow - LeftWrist);
                double AngleLeftShoulder = AngleBetweenTwoVectors(LeftShoulder - ShoulderCenter, LeftShoulder - LeftElbow);
    
                double[] Angles = {AngleRightElbow, AngleRightShoulder, AngleLeftElbow, AngleLeftShoulder};
                return Angles;
            }
    }
