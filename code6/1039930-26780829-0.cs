    static class GlobalTempStorageVariable
    {
        static ObservableCollection<SampleEntityList> zoneListGlobal
                                        = new ObservableCollection<SampleEntityList>();
        static ObservableCollection<SampleEntityList> ztowListGlobal
                                        = new ObservableCollection<SampleEntityList>();
        public static ObservableCollection<SampleEntityList> CurrentListOfInventories
        {
            get { return zoneListGlobal; }
            set { zoneListGlobal = value; }
        }
        public static ObservableCollection<SampleEntityList> CurrentSelectedInventories
        {
            get { return ztowListGlobal; }
            set { ztowListGlobal = value; }
        }
    }
  
