    public static class GlobalTempStorageVariable
    {
    
        ObservableCollection<SampleEntityList> zoneListGlobal
                                        = new ObservableCollection<SampleEntityList>();
        ObservableCollection<SampleEntityList> ztowListGlobal
                                        = new ObservableCollection<SampleEntityList>();
    
    
        public static ObservableCollection<SampleEntityList> GetCurrentListOfInventories()
        {
            return zoneListGlobal;
        }
    
        public static ObservableCollection<SampleEntityList> GetCurrentSelectedInventories()
        {
            return ztowListGlobal;
        }
    
    }
