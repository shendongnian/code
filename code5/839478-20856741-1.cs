        public class Payload
        {
            public int result { get; set; }
            public int id { get; set; }
            public Error error { get; set; }
            public Dictionary<string, Device> data { get; set; }
        }
        public class Device
        {
            public string css_class { get; set; }
            public string default_name { get; set; }
            public string device_type { get; set; }
            public string did { get; set; }
            public string gid { get; set; }
            public int has_subdevice_count { get; set; }
            public int has_time_series { get; set; }
            public int is_actuator { get; set; }
            public int is_sensor { get; set; }
            public int is_silent { get; set; }
            public LastData last_data { get; set; }
            public Meta meta { get; set; }
            public string node { get; set; }
            public string shortName { get; set; }
            public Dictionary<string, Device> subDevices { get; set; }
            public string vid { get; set; }
        }
        public class LastData
        {
            public string DA { get; set; }
            public long timestamp { get; set; }
        }
        public class Meta
        {
        }
        public class Error
        {
        }
