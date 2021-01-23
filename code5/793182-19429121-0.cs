    class MyItem
    {
        public string No { get; set; }
        public string CityName { get; set; }
        public string OtherCityName { get; set; }
        public string Period { get; set; }
        public MyItem(string No, string CityName, string OtherCityName, string Period)
        {
            this.No = No;
            this.CityName = CityName;
            this.OtherCityName = OtherCityName;
            this.Period = Period;
        }
    }
