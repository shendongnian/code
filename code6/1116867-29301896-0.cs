    public class Rootobject
    {
        public _1000 _1000 { get; set; }
    }
    public class _1000
    {
        public int id { get; set; }
        public string name { get; set; }
        public Path_From_Root[] path_from_root { get; set; }
        public Children_Categories[] children_categories { get; set; }
        public bool attributes_required { get; set; }
        public int max_pictures_per_item { get; set; }
        public int max_title_length { get; set; }
        public object max_price { get; set; }
        public object min_price { get; set; }
        public bool listing_allowed { get; set; }
    }
    public class Path_From_Root
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Children_Categories
    {
        public int id { get; set; }
        public string name { get; set; }
    }
