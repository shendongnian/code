    public class RegionWrapper : IShapeWrapper
    {
        private Region _region;
        public RegionWrapper()
        {
            _region = new Region();
        }
        public void load()
        {
            _region.load();
        }
    }
    public class AreaWrapper : IShapeWrapper
    {
        private Area _area;
        public AreaWrapper()
        {
            _area = new Area();
        }
        public void load()
        {
            _area.load();
        }
    }
