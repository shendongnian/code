     public void OnBodyFrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            using (var frame = e.FrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    frame.GetAndRefreshBodyData(this.bodies);
                    
                    var trackedBody = this.bodies.Where(b => b.IsTracked).FirstOrDefault();
                    if (trackedBody != null)
                    {
                            List<Joint> myJoints = new List<Joint>();
                            myJoints.Add(trackedBody.Joints[JointType.FootLeft]);
                            myJoints.Add(trackedBody.Joints[JointType.AnkleLeft]);
                            myJoints.Add(trackedBody.Joints[JointType.KneeLeft]);
                            if (myJoints.TrueForAll(x => x.TrackingState == TrackingState.Tracked))
                            {
                                Vector3D KneeLeft = new Vector3D(trackedBody.Joints[JointType.KneeLeft].Position.X, trackedBody.Joints[JointType.KneeLeft].Position.Y, trackedBody.Joints[JointType.KneeLeft].Position.Z);
                                Vector3D AnkleLeft = new Vector3D(trackedBody.Joints[JointType.AnkleLeft].Position.X, trackedBody.Joints[JointType.AnkleLeft].Position.Y, trackedBody.Joints[JointType.AnkleLeft].Position.Z);
                                Vector3D FootLeft = new Vector3D(trackedBody.Joints[JointType.FootLeft].Position.X, trackedBody.Joints[JointType.FootLeft].Position.Y, trackedBody.Joints[JointType.FootLeft].Position.Z);
                                Console.WriteLine("#1: " + AngleBetweenTwoVectors(AnkleLeft - KneeLeft, AnkleLeft - FootLeft));
                            }
                    }
                    else
                    {
                        this.OnTrackingIdLost(null, null);
                    }
                }
            }
        }
        public double AngleBetweenTwoVectors(Vector3D vectorA, Vector3D vectorB)
        {
            double dotProduct = 0.0;
            vectorA.Normalize();
            vectorB.Normalize();
            dotProduct = Vector3D.DotProduct(vectorA, vectorB);
            return (double)Math.Acos(dotProduct) / Math.PI * 180;
        }
