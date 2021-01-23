    [DataContract]
    public class P
    {
        [DataMember(Name="r")]
        public string R { get; set; }
        [DataMember(Name="savedSearches")]
        public IList<SavedSearch> SavedSearches { get; set; }
        [DataContract]
        public class SavedSearch
        {
            [DataMember(Name="saved-search")]
            public SavedSearchItem SavedSearchItem { get; set; }
        }
        [DataContract]
        public class SavedSearchItem
        {
            [DataMember(Name="@a")]
            public string A { get; set; }
            [DataMember(Name = "@b")]
            public string B { get; set; }
            [DataMember(Name = "@c-d")]
            public string CD { get; set; }
        }
    }
