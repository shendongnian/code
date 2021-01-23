    class SPeriodInfo
    {
        public string   StrItem   { get; private set; }
        public int      NItemData { get; private set; }
        public float    FPeriod   { get; private set; }
    
        public SPeriodInfo(string item, int itemData, float period)
        {
            StrItem = item;
            NItemData = itemData;
            FPeriod = period;
        }
    }
