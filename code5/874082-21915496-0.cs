    private class StartSettings
    {
        public string CityReg;
        public int CityNum;
        public string ZipReg;
        public int ZipNum;
        public string StreetReg;
        public int StreetNum;
        public string NumberReg;
        public int NumberNum;
    }
    var configString = File.ReadAllText(configFilePath);
    var config = JsonConvert.DeserializeObject<StartSettings>(configString);
