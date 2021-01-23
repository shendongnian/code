    private static readonly Random Random = new Random();
    public static string GetApiKey()
    {
        var bytes = new byte[48];
        Random.NextBytes(bytes);
        var result = Convert.ToBase64String(bytes);
        return result;
    }
