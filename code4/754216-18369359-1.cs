        var lst = new List<string> { "Sheet1!$A$9:$B$172", "Sheet1!$AY$77:$AZ$172",     "Sheet1!$E$41:$F$172", "Sheet1!$A$10:$B$172", "Sheet1!$A$1:$B$172" };
        var sorted = lst.OrderBy(
            str => Regex.Split(str.Replace(" ", ""), "([0-9]+)").Select(convert),
            new ExcelNameComparer<object>());
        foreach (var sort in sorted)
        {
            System.Diagnostics.Debug.Print(sort);
        }
