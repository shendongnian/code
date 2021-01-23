            // interleaved x and y values, so like x1, y1, x2, y2 etc.
            double[] xy = new double[]{456874.625438354,5145767.7929015327};
            // z values if any.  Typically this is just 0.
            double[] z = new double[]{0};
            // Source projection information.
            ProjectionInfo source = DotSpatial.Projections.KnownCoordinateSystems.Projected.UtmWgs1984.WGS1984UTMZone32N;
            // Destination projection information.
            ProjectionInfo dest = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
            // Call the projection utility.
            DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, source, dest, 0, 1);
