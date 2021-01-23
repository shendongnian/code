    public static class Extensions
    {
        public static string GetFullName(this FileInfo fInfo)
        {
            if (fInfo == null)
            {
                return String.Empty;
            }
            return fInfo.FullName;
        }
    }
