    public static class GuidExtensions
    {
        public static string ToMyString(this Guid guid)
        {
            return guid.ToString("N");
        }
    }
    // elsewhere
    Guid guid = /* ... */;
    Console.WriteLine(guid.ToMyString());
