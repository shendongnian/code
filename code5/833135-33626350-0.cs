    [Serializable]
    public class StoredData
    {
        [Datamember(Name = "Clip", Order = 1)]
        public String storedClip;
        [Datamember(Name = "Time", Order = 2)]
        public DateTime storedTime;
    }
