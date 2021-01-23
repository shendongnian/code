    List<MyItem> list = new List<MyItem>();
    List<string[]> input = new List<string[]>();
    input.Add(new[] { "0", "Detroit", "Chicago", "Week 2" });
    input.Add(new[] { "1", "Detroit", "Baltimore", "Week 3" });
    input.Add(new[] { "2", "Chicago", "Boston", "Week 2" });
    input.Add(new[] { "3", "Detroit", "Tampa", "Week 2" });
    
    foreach (var item in input)
    {
        if (!list.Any(r => r.CityName == item[1] && r.Period == item[3]))
        {
            list.Add(new MyItem(item[0], item[1], item[2], item[3]));
        }
    }
