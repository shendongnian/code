    var obj = JsonConvert.DeserializeObject<Withings.RootObject>(json);
---
    public class Withings
    {
        public class Measure
        {
            public int value { get; set; }
            public int type { get; set; }
            public int unit { get; set; }
        }
        public class Measuregrp
        {
            public int grpid { get; set; }
            public int attrib { get; set; }
            public int date { get; set; }
            public int category { get; set; }
            public List<Measure> measures { get; set; }
        }
        public class Body
        {
            public int updatetime { get; set; }
            public List<Measuregrp> measuregrps { get; set; }
        }
        public class RootObject
        {
            public int status { get; set; }
            public Body body { get; set; }
        }
    }
