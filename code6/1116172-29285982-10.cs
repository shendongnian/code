    public static class TestFlatten
    {
        public static IEnumerable<FlatData> GetFlatData()
        {
            // Get sample data for testing purposes.
            var list = new List<FlatData>
            {
                new FlatData { Id = 1, ParentId = 0, Text = "Some Root Node" },
                new FlatData { Id = 2, ParentId = 0, Text = "Anadolu Satış Merkezi" },
                new FlatData { Id = 3, ParentId = 2, Text = "Emrullah Çelik" },
                new FlatData { Id = 4, ParentId = 3, Text = "Ahmet İşler" },
                new FlatData { Id = 5, ParentId = 4, Text = "Elpa Pazarlama Nazmi Appak" },
                new FlatData { Id = 6, ParentId = 4, Text = "Elpa Pazarlama Nazmi Appak Redux" },
                new FlatData { Id = 11, ParentId = 1, Text = "Some Child of Some Root Node" },
            };
            return list;
        }
        public static void Test()
        {
            var nodes = GetFlatData();
            var flatNodes = nodes.FlattenTree(d => d.Id, d => d.ParentId);
            var results = flatNodes.Select(
                list => list
                    .Select((d, i) => new KeyValuePair<int, FlatData>(i, d))
                    .ToDictionary(pair => string.Format("level{0}", pair.Key + 1), pair => pair.Value.Text))
                .ToList();
            var json = JsonConvert.SerializeObject(new { data = results }, Formatting.Indented);
            Debug.WriteLine(json);
        }
    }
