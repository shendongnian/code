    public class KeyNamePair
    {
        public int Key { get; set; }
        public string Name { get; set; }
    }
    List<KeyNamePair> list = new List<KeyNamePair>
        {
            new KeyNamePair() {Key = 1, Name = "Day 1"},
            new KeyNamePair() {Key = 2, Name = "Day 11"},
            new KeyNamePair() {Key = 4, Name = "Day 5"},
            new KeyNamePair() {Key = 6, Name = "Day 13"}
        };
    var sortedList = list.Select(x => x).OrderBy(x => x.Key).ToList();
