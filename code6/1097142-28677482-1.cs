    // Filter string which have non-numeric characters for the the first two letters (Condition 1)
    List<String> pass1 = items.Where(x => x.Length > 2 && x.Substring(0, 2).ToCharArray().Intersect(chars).Count() == 2).ToList();
    // Get distinct two non-numeric character startings
    List<string> pass2 = pass1.GroupBy(x => x.Substring(0, 2)).Where(c => c.Count() > 1).Select(s => s.Key).ToList();
    // Get all records starting with these letters
    List<string> pass3a = items.Where(x => pass2.Contains(x.Substring(0, 2))).Select(x => x).ToList();
    // Remove characters after the first occurance of a numeric character from all records having at least one  numeric character and satisfying the Condition 1. This is also where e use the Extension method.
    List<string> pass3b = pass3a.Where(x => x.RemoveAfterNumber() != null).Select(x => x.RemoveAfterNumber()).ToList();
    // Group by the repetitions and format as you require
    List<string> result = pass3b.Select(x => x + "*").Distinct().ToList();
