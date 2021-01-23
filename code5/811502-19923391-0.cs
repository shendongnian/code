    var list = new List<string>
                   {
                       "FF", "ABC", "CC", "FF", "FF"
                   };
    string search = "FF";
    
    var result = list.GroupBy(l => l).Where(g => g.Key.Contains(search)).Select(s => new Tuple<string, int>(s.Key, s.Count())).FirstOrDefault();
