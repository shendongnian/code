    public static Version ParseToVersion(this string input)
    {
        Version result = null;
        Version.TryParse(input, out result);
        return result;
    }
