            var geoproj = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
            var d1 = new FeatureSet { Projection = geoproj };
            //var c1 = new Coordinate(31.877484, 34.736723);
            //var c2 = new Coordinate(31.879607, 34.732362);
            var c1 = new Coordinate(0, -1);
            var c2 = new Coordinate(0, 1);
            var line1 = new LineString(new[] { c1, c2 });
            d1.AddFeature(line1);
           
            var d2 = new FeatureSet { Projection = geoproj };
            //var c3 = new Coordinate(31.882391, 34.73352);
            //var c4 = new Coordinate(31.875502, 34.734851);
            var c3 = new Coordinate(-1, 0);
            var c4 = new Coordinate(1, 0);
            var line2 = new LineString(new[] { c3, c4 });
            d2.AddFeature(line2);
            // To create a Point featureset with the intersections
            var result = new FeatureSet(FeatureType.Point) { Projection = geoproj };
            foreach (IFeature feature in d1.Features)
            {
                foreach (IFeature other in d2.Features)
                {
                    if (feature.Intersects(other))
                    {
                        result.AddFeature(feature.Intersection(other));
                    }
                }
            }
            // To keep only d1 lines that intersect with d2
            result = new FeatureSet { Projection = geoproj };
            foreach(IFeature feature in d1.Features){
                foreach(IFeature other in d2.Features){
                    if(feature.Intersects(other)){
                        result.AddFeature(feature); 
                    }
                }
            }
            // Alternately to combine the intersecting lines into a cross
            result = new FeatureSet { Projection = geoproj };
            foreach (IFeature feature in d1.Features)
            {
                IFeature union = feature;
                Boolean keep = false;
                foreach (IFeature other in d2.Features)
                {
                    if (feature.Intersects(other))
                    {
                        union = union.Union(other);
                        keep = true;
                    }
                }
                if (keep)
                {
                    result.AddFeature(union);
                }
            }
