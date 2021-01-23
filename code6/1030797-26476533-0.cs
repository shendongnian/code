    class Region
    {
        private int myIndex;
        private List<Point> regionCoordinates;
        private List<int> regionIntensitiesDistinct;
        public Region(List<Point> regionCoordinates, List<int> regionIntensities, int index)
        {
            this.regionCoordinates = regionCoordinates;
            this.regionIntensitiesDistinct = regionIntensities.Distinct().ToList();
            this.myIndex = index;
        }
        public string MyDescription
        {
            get
            {
                return "Region-" + myIndex;
            }
        }
        public List<Point> getRegionCoordinates()
        {
            return regionCoordinates;
        }
        public List<int> getRegionIntensitiesDistinct()
        {
            return regionIntensitiesDistinct;
        }
    }
