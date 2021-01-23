    class FT_DEVICE_wrapper
    {
        public FT_DEVICE_LIST_INFO_NODE INFO_NODE { get; set; }
        public FT_DEVICE_wrapper(FT_DEVICE_LIST_INFO_NODE data_)
        { INFO_NODE = data_; }
        public override string ToString()
        {
            return string.Format("ID = {0} LocID = {1} SNr = {2} ({3}) ", 
                INFO_NODE.ID, INFO_NODE.LocId, INFO_NODE.SerialNumber, INFO_NODE.Description);
        }
    }
