    public static class StringSplitExtension
    {
        public static string[] SplitByCount(this string input, char[] separator, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count");
            if (count == 0)
                return new string[0];
            var numberOfSeparators = input.Count(separator.Contains);
            var numActualReplaces = Math.Min(count, numberOfSeparators + 1);
            var splitString = new string[numActualReplaces];
            var index = -1;
            for (var i = 1; i <= numActualReplaces; i++)
            {
                var nextIndex = input.IndexOfAny(separator, index + 1);
                if (nextIndex == -1 || i == numActualReplaces)
                    splitString[i - 1] = input.Substring(index + 1);
                else
                    splitString[i - 1] = input.Substring(index + 1, nextIndex - index - 1);
                index = nextIndex;
            }
            return splitString;
        }
    }
