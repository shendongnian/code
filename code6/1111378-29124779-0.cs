    List<List<MyDate>> Get6MonthsCombinations(List<MyDate> input)
    {
        List<List<MyDate>> output = new List<List<MyDate>>();
        var ordered = input.OrderBy(x => x.Year).ThenBy(x => x.Month).ToList();
        if(ordered.Count == 0)
            return output;
        DateTime periodStart = new DateTime(ordered[0].Year,ordered[0].Month, 1);
        output.Add(new List<MyDate>());
        foreach (MyDate md in ordered)
        { 
            DateTime month = new DateTime(md.Year, md.Month,1 );
            if ((month - periodStart).Days > 183)
            {
                output.Add(new List<MyDate>());
                periodStart = month;
            }
            output.Last().Add(md);
        }
        return output;
    }
