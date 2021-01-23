        static public PointF reLocation(PointF pt)
        {
            PointF[] eLocations = new PointF[] { pt };
            Matrix RM = ScaleMatrix.Clone();
            RM.Invert();
            RM.TransformPoints(eLocations);
            return eLocations[0];
        }
        static public PointF unreLocation(PointF pt)
        {
            PointF[] eLocations = new PointF[] { pt };
            Matrix RM = ScaleMatrix.Clone();
            RM.TransformPoints(eLocations);
            return eLocations[0];
        }
