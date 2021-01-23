    class SPeriodInfo
    {
        public string   StrItem   { get; set; }
        public int      NItemData { get; set; }
        public float    FPeriod   { get; set; }
    
        public SPeriodInfo(string item, int itemData, float period)
        {
            StrItem = item;
            NItemData = itemData;
            FPeriod = period;
        }
    }
