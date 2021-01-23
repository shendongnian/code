    private static bool StartsWithM(string s) {
        return s.StartsWith("M");
    }
    private static string PassThrough(string s) {
        return s;
    }
    ...
    var resultSet4 = products
                .Where(StartsWithM)
                .OrderByDescending(PassThrough)
                .Select(PassThrough); // <<== Again, this can be removed
