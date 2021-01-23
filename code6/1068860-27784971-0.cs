    foreach (Joint joint in skeleton.Joints)
                {
                    if (joint.TrackingState == JointTrackingState.Tracked)
                    {
                        //Do something                    
                    }
                    else if (joint.TrackingState == JointTrackingState.Inferred)
                    {
                        //Do something else                   
                    }
                }
            
