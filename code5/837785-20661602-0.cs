    private static List<Dictionary<string,object>> ExtractSeries(string JSONDs, string seedA,string seedB,string groupby)
    {
        var jss = new JavaScriptSerializer();
        var l = from item in jss.Deserialize<List<Dictionary<string, object>>>(JSONDs)
                select new { val = new Dictionary<string, object>(){{ seedA, item[seedA]}, {seedB, item[seedB] }}, groupKey = item[groupby] } into sampleObj
                group sampleObj by sampleObj.groupKey into g
                select new { Name = g.Key, Data = g.Select(i=>i.val) };
        return l.ToList();
    }
