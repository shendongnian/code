    // Use ToList to avoid iterating matches multiple times
    var matches = Regex.Matches(data, re).Cast<Match>().ToList();
    // For each element, iterate all matches, and pull in the value for e.Ordinal
    var xmlResults = elements
        .SelectMany(e => matches.Select(m => new {
            Name = e.Name, Value = m.Groups[e.Ordinal].Value
        }))
        // Now construct the string that looks like XML
        .Select(nv => string.Format("<{0}>{1}</{0}>", nv.Name, nv.Value));
