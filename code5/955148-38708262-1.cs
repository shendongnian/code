        public GeoboundingBox GetBounds(MapControl map)
        {
            if(map.Center.Position.Latitude == 0) { return default(GeoboundingBox); }
            double degreePerPixel = (156543.04 * Math.Cos(map.Center.Position.Latitude * Math.PI / 180)) / (111325 * Math.Pow(2, map.ZoomLevel));
            double mHalfWidthInDegrees = map.ActualWidth * degreePerPixel / 0.9;
            double mHalfHeightInDegrees = map.ActualHeight * degreePerPixel / 1.7;
            double mNorth = map.Center.Position.Latitude + mHalfHeightInDegrees;
            double mWest = map.Center.Position.Longitude - mHalfWidthInDegrees;
            double mSouth = map.Center.Position.Latitude - mHalfHeightInDegrees;
            double mEast = map.Center.Position.Longitude + mHalfWidthInDegrees;
            GeoboundingBox mBounds = new GeoboundingBox(
                new BasicGeoposition()
                {
                    Latitude = mNorth,
                    Longitude = mWest
                },
                new BasicGeoposition()
                {
                    Latitude = mSouth,
                    Longitude = mEast
                });
            Debug.WriteLine("New Bounds: NW = " + mNorth + ":" + mWest + " SE = " + mSouth + ":" + mEast);
            return mBounds;
        }
