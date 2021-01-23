    var fileListEntries = lines
        .Where(l => !l.StartsWith("#"))
        .Select(l => {
            string[] columns = l.Split(';');
            if (Path.IsPathRooted(column[0])) {
                string root = Path.GetPathRoot(columns[0]);
                columns[0] = Path.Combine(@"X:\", columns[0].Substring(root.Length));
            }
            return columns;
        })
        .ToArray();
