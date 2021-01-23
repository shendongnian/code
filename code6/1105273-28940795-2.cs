    class Item
    {
        public string name { get; set; }
        public string place { get; set; }
    }
    ....
    var t = new Item {name = "abc", place = "xyz"};
    var s = JsonConvert.SerializeObject(t);
    Debug.Assert(s == "{\"name\":\"abc\",\"place\":\"xyz\"}");
