    public class DropBan : TerrariaPlugin
    {  
        private Config config;
        bool IsExcluded(int id)
        {
            if (config == null)
            {
                ReadConfig();
            }
            return config != null && config.Exclusions != null && config.Exclusions.Contains(id);
        }
        public class Config
        {
            public int[] Exclusions = { 267, 188 };
        }
        // Rest as as shown at http://pastebin.com/RgBmtus9
    }
