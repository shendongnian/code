    var list = new List<List<string>>
    {
        new List<string> {"tom", "abc", "$525.34", "$123"},
	    new List<string> {"dick", "xyz", "$100", "$234"},
	    new List<string> {"harry", "", "$250.01", "$40"},
	    new List<string> {"bob", "", "$250.01", ""}
    };
    decimal num;
    var itemsPerLine = list[0].Count; // 4
    var res = list.SelectMany(line => line);
                  .Select((s, i) => new { Text = s, Index = i })
                  .GroupBy(i => i.Index % itemsPerLine) // transformed matrix here
                  .Select(g => g.Sum(i => 
                       decimal.TryParse(i.Text, NumberStyles.AllowCurrencySymbol | 
                                                NumberStyles.AllowDecimalPoint, 
                                                new CultureInfo("en-US"), out num) 
                                                ? num : 0));
