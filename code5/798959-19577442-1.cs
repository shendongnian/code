    public static class Configuration
    {
        // public set so you can change the configfile location if necessary
        public static string ConfigurationFile { get; set; }
        // variables from configuration file, private set so they cannot be changed except by changing the configuration and reloading
        public static string Inc_interval { get; private set; }
        public static string Day_Time { get; private set; }
        /// <summary>
        /// Static constructor - will be called the first time this class is accessed
        /// </summary>
        static Configuration()
        {
            ConfigurationFile = @"C:\somefile";
            ReadConfigFile();
        }
        /// <summary>
        /// Calling this method will reload the configuration file
        /// </summary>
        public static void Reload()
        {
            ReadConfigFile();
        }
        /// <summary>
        /// Logic for reading the configuration file
        /// </summary>
        private static void ReadConfigFile()
        {
            // ToDo: Read file here and fill properties
            using (StreamReader rd = new StreamReader(ConfigurationFile))
            {
                while (!rd.EndOfStream)
                {
                    string line = rd.ReadLine();
                    if (line.StartsWith("Day_Time:"))
                        Day_Time = line.Remove(0, 9);
                    else if (line.StartsWith("Inc_interval:"))
                        interval = line.Remove(0, 13);
                }
            }
            
        }
    }
