    public class StarredData
    {
        public string StarredImage { get; set; }
        public string StarredTitle { get; set; }
        public StarredData() { }
        public StarredData(string itemImageSet, string itemNameSet)
        {
            StarredImage = itemImageSet;
            StarredTitle = itemNameSet;
        }
    }
