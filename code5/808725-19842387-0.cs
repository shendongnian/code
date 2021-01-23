        var whitelist = typeof (DocumentTrackerChaseReport)
            .GetProperties()
            .Where(x => Attribute.IsDefined(x, typeof (DescriptionAttribute)));
        var rows = things.Select(o => whitelist.Select(v => v.GetValue(o) ?? ""));
        Console.WriteLine(
            string.Join(", ", whitelist.Select(x => x.Name)));
        foreach (var row in rows) {
            Console.WriteLine(string.Join(", ", row.Select(x => x.ToString())));
        }
