    public static class Extensions
    {
        public static string[] Split(this string input, string delimiter, int prependNullCount)
        {
            var defaultSplit = input.Split(new string[] { delimiter }, StringSplitOptions.None);
            string[] result = new string[defaultSplit.Length + prependNullCount];
            defaultSplit.CopyTo(result, prependNullCount);
            return result;
        }
    }
