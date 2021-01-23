    private static Random random = new Random();
    
    public static string GetVoucherNumber(int length)
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var result = new string(
            Enumerable.Repeat(chars, length)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
    
        return result;
    }
