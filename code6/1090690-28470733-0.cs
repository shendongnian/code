    [Serializable]
    public class srFilterData
    {
        public String filterType { get; set; }
        public UserData data { get; set; }
    }
    [Serializable]
    public class UserData
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
    }
