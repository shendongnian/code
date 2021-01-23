        public class Rootobject
        {
            public string indexfileversion { get; set; }
            public string type { get; set; }
            public Build[] builds { get; set; }
        }
        public class Build
        {
            public string version { get; set; }
            public string build { get; set; }
            public string rawVersion { get; set; }
            public string path { get; set; }
        }
