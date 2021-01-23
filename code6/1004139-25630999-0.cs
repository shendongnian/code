    var duplicates = Persons
        .GroupBy(key => new { key.Number, key.CompanyId }, a=>a.Name)
        .Where(y => y.Count() > 1);
    var sb = new StringBuilder();
    foreach (var duplicate in duplicates)
    {
        sb.AppendLine(String.Format("{0} have been assigned the same Number {1} for Company #{2}",
                                    String.Join(" and ", duplicate), duplicate.Key.Number,
                                    duplicate.Key.CompanyId));
    }
    var message = sb.ToString();
