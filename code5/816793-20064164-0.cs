    DateTime OrderableItem (string e) {
        var date = e.Substring(0, 10);
        return DateTime.ParseExact(date, "MM-dd-yyyy", CultureInfo.InvariantCulture)
    }
    int OrderableCount (string e) {
        var m = Regex.Match(e, @"-count=(\d+)", RegexOptions.IgnoreCase);
        return int.Parse(m.Groups[1].Value);
    }
    var res = seq.OrderBy(OrderableDate).ThenBy(OrderableCount);
