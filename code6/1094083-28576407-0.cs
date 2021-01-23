        public class All
        {
            public Devices devices { get; set; }
            public Dictionary<string, Structure> structures { get; set; }
        }
        public class Devices
        {
            public Dictionary<string, Thermostat> thermostats { get; set; }
        }
        public class Structure
        {
            public string name { get; set; }
            public string country_code { get; set; }
            public string time_zone { get; set; }
            public string away { get; set; }
            public IList<string> thermostats { get; set; }
            public string structure_id { get; set; }
        }
        public class Thermostat
        {
            public int humidity { get; set; }
            public string locale { get; set; }
            public string temperature_scale { get; set; }
            public bool is_using_emergency_heat { get; set; }
            public bool has_fan { get; set; }
            public string software_version { get; set; }
            public bool has_leaf { get; set; }
            public string device_id { get; set; }
            public string name { get; set; }
            public bool can_heat { get; set; }
            public bool can_cool { get; set; }
            public string hvac_mode { get; set; }
            public double target_temperature_c { get; set; }
            public int target_temperature_f { get; set; }
            public double target_temperature_high_c { get; set; }
            public int target_temperature_high_f { get; set; }
            public double target_temperature_low_c { get; set; }
            public int target_temperature_low_f { get; set; }
            public double ambient_temperature_c { get; set; }
            public int ambient_temperature_f { get; set; }
            public double away_temperature_high_c { get; set; }
            public int away_temperature_high_f { get; set; }
            public double away_temperature_low_c { get; set; }
            public int away_temperature_low_f { get; set; }
            public string structure_id { get; set; }
            public bool fan_timer_active { get; set; }
            public string name_long { get; set; }
            public bool is_online { get; set; }
            public DateTime last_connection { get; set; }
        }
