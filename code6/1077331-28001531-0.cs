    class TagData
    {
        public string name { get; set; }
        public int longitude { get; set; }
        //...
    }
    var item JsonConvert.DeserializeObject<List<TagData>>(result);
