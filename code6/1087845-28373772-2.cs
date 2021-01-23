        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }
        public class Bounds
        {
            public Location northeast { get; set; }
            public Location southwest { get; set; }
        }
        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Geometry
        {
            public Bounds bounds { get; set; }
            public Location location { get; set; }
            public string location_type { get; set; }
            public Bounds viewport { get; set; }
        }
        public class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public bool partial_match { get; set; }
            public List<string> types { get; set; }
        }
        public class RootObject
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }
    (You could also use [Paste JSON as Classes](https://stackoverflow.com/q/18526659/3744182) or https://jsonutils.com/ to generate your initial type definitions.)
