    var obj = JsonConvert.DeserializeObject<List<ItemContainer>>(json);
----
    public class ItemContainer
    {
        public Dictionary<string,Item> Items { get; set; }
    }
    public class Item
    {
        public string IdNummer { get; set; }
        public string Title { get; set; }
        public string Server { get; set; }
        public string PublishPoint { get; set; }
        public string Filename { get; set; }
        public string activated { get; set; }
        public string Date { get; set; }
        public string Filesize { get; set; }
        public string Thumbnail { get; set; }
        public string Comments { get; set; }
        public string UserToken { get; set; }
        public string ItemTokenNumber { get; set; }
        public string Category { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
