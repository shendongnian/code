    var seriesContent = new Dictionary<string, object>
    {
        {"name", "series1"},
        {"data", new[] {new[]{0,2},new[]{1,3},new[]{2,1},new[]{3,4}}}
    };
    
    var series = new Dictionary<string, object>
    {
        {"series", seriesContent}
    };
    
    var s = JsonConvert.SerializeObject(series);
