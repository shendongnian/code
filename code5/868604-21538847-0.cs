        public static Angle3D GetAngles(Matrix4x4 source)
        {
            double thetaX, thetaY, thetaZ = 0.0;
            thetaX = Math.Asin(source.M32);
            if (thetaX < (Math.PI / 2))
            {
                if (thetaX > (-Math.PI / 2))
                {
                    thetaZ = Math.Atan2(-source.M12, source.M22);
                    thetaY = Math.Atan2(-source.M31, source.M33);
                }
                else
                {
                    thetaZ = -Math.Atan2(-source.M13, source.M11);
                    thetaY = 0;
                }
            }
            else
            {
                thetaZ = Math.Atan2(source.M13, source.M11);
                thetaY = 0;
            }
            // Create return object.
            Angle3D angles = new Angle3D(thetaX, thetaY, thetaZ);
            // Convert to degrees.;
            angles.Format = AngleFormat.Degrees;
            // Return angles.
            return angles;
        }
