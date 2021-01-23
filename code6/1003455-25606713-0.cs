    void sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
            {
                try
                {
                    using (var skeletonFrame = e.OpenSkeletonFrame())
                    {
                        if (skeletonFrame == null)
                            return;
    
                        if (skeletons == null ||
                            skeletons.Length != skeletonFrame.SkeletonArrayLength)
                        {
                            skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                        }
                        skeletonFrame.CopySkeletonDataTo(skeletons);
                    }
                    Skeleton closestSkeleton = skeletons.Where(s => s.TrackingState == SkeletonTrackingState.Tracked)
                                                        .OrderBy(s => s.Position.Z * Math.Abs(s.Position.X))
                                                        .FirstOrDefault();
                    if (closestSkeleton == null)
                        return;
    
                    var rightFoot = closestSkeleton.Joints[JointType.FootRight];
                    var leftFoot = closestSkeleton.Joints[JointType.FootLeft];
                    var rightHand = closestSkeleton.Joints[JointType.HandRight];
                    var leftHand = closestSkeleton.Joints[JointType.HandLeft];
    
                    if (rightFoot.TrackingState == JointTrackingState.NotTracked ||
                        rightHand.TrackingState == JointTrackingState.NotTracked ||
                        leftHand.TrackingState == JointTrackingState.NotTracked)
                    {
                        //Don't have a good read on the joints so we cannot process gestures
                        return;
                    }
    
                    CoordinateMapper mapper = sensor.CoordinateMapper;
                    var point = mapper.MapSkeletonPointToColorPoint(closestSkeleton.Joints[JointType.Head].Position, sensor.ColorStream.Format);
                    var point1 = mapper.MapSkeletonPointToColorPoint(rightHand.Position, sensor.ColorStream.Format);
                    var point2 = mapper.MapSkeletonPointToColorPoint(leftHand.Position, sensor.ColorStream.Format);
                        // - Put Your Draw Code Here insted of the following:
                        SetEllipsePosition(ellipseRightFoot, rightFoot, false);
                        SetEllipsePosition(ellipseLeftFoot, leftFoot, false);
                        SetEllipsePosition(ellipseLeftHand, leftHand, isBackGestureActive);
                        SetEllipsePosition(ellipseRightHand, rightHand, isForwardGestureActive);
                        SetImagePosition(punhal, rightHand);
                        SetImagePosition2(punhal2, leftHand);
                        // -------------------------------------------------
                catch
                {
                    myException(this, new EventArgs());
                }
            }
