    class Area {
        public Area() { Values = new int[32]; }
        public int[] Values { get; set; }
        public int AreaNumber { get; set; }
    }
    var areas = new List<Area>();
    foreach (var record in databaseRecords) {
        var area = // find area from list based on AreaNumber. If not there, add it
        area[record.Day - 1] = record.Hour;
    }
