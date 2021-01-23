    public static bool AreCharsUnique(string str)
    {
        var charset = new HashSet<char>();
        foreach (char c in str) {
            if (charset.Contains(c)) {
                return false;
            } else {
                charset.Add(c);
            }
        }
        return true;
    }
