    class SPeriodInfo
    {
        public string   StrItem   { get; private set; }
        public int      nItemData { get; private set; }
        public float    fPeriod   { get; private set; }
    
        public SPeriodInfo(string item, int itemData, float period)
        {
            strItem = item;
            nItemData = itemData;
            fPeriod = period;
        }
    }
