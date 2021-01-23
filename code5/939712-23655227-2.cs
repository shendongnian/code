    public static HelpersModel.LatLonAlt FindBottomLeftExtent(HelpersModel.LatLonAlt startpoint)
        {
            // first move left
            HelpersModel.LatLonAlt movedleft = CalculateDerivedPosition(startpoint, 72.42, 270);
            // move down
            HelpersModel.LatLonAlt moveddown = CalculateDerivedPosition(movedleft, 72.42, 180);
            return moveddown;
        }
        public static HelpersModel.LatLonAlt FindTopRightExtent(HelpersModel.LatLonAlt startpoint)
        {
            // first move right
            HelpersModel.LatLonAlt movedright = CalculateDerivedPosition(startpoint, 72.42, 90);
            // move up
            HelpersModel.LatLonAlt movedup = CalculateDerivedPosition(movedright, 72.42, 0);
            return movedup;
        }
