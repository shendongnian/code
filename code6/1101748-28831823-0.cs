    public static double Percentage(string str1, string str2) {
        // Handling of empty strings. No divisions by zero here!
        if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2)) {
            return 0.0;
        }
        // str2 is contained in str1
        if (str1.Contains(str2)) {
            return 100.0 * str2.Length / str1.Length;
        }
        // str1 is contained in str2
        if (str2.Contains(str1)) {
            return 100.0 * str1.Length / str2.Length;
        }
        // No matching
        return 0.0;
    }
