    string[][] twoDArrOfString = new string[2][];
    var res = twoDArrOfString
        .Where(inner => inner != null) // Cope with uninitialised inner arrays.
        .Select(inner => inner.ToList()) // Project each inner array to a List<string>
        .ToList(); // Materialise the IEnumerable<List<string>> to List<List<string>>
