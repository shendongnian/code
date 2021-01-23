    var addrs = root.locationResponse.locations
                    .Select(x => x.Split(','))
                    .Select(parts =>
                    {
                        var l = new Location();
                        var props = l.GetType().GetProperties();
                        foreach (var part in parts)
                        {
                            var kv = part.Split(new char[] { ':' }, 2);
                            var prop = l.GetType().GetProperty(kv[0]);
                            if(prop != null)
                                prop.SetValue(l, kv[1]);
                                    
                        }
                        return l;
                    })
                    .ToList();
---
    public class Location
    {
        public string E911AID { get; set; }
        public string streetDir { get; set; }
        public string street { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string streetNameSuffix { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string houseNum { get; set; }
    }
    public class LocationResponse
    {
        public List<string> locations { get; set; }
    }
    public class RootObject
    {
        public LocationResponse locationResponse { get; set; }
    }
