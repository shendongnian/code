    string input = "AAA-1111,AAA-666,SMT-QWQE,SMT-TTTR";
    Dictionary<string, string> output = input.Split(',') // first split by ','
        .Select(el => el.Split('-')) // then split each inner element by '-'
        .GroupBy(el => el.ElementAt(0), el => el.ElementAt(1)) // group by the part that comes before '-'
        .ToDictionary(grp => grp.Key, grp => string.Join(",", grp)); // convert to a dictionary with comma separated values
-
    output["AAA"] // 1111,666
    output["SMT"] // QWQE,TTTR
