    public static class StringExtensions
    {
        public static IEnumerable<String> StreamSplit(this String thisStr, char splitChar)
        {
            if (thisStr == null)
                throw new ArgumentNullException();
            Int32 lastSplitterIndex = -1;
            for (Int32 i = 0; i < thisStr.Length; i++)
            { 
                if (thisStr[i] == splitChar)
                {
                     yield return thisStr.Substring(lastSplitterIndex + 1, i - lastSplitterIndex - 1);
                     lastSplitterIndex = i;
                }
            }
            yield return thisStr.Substring(lastSplitterIndex + 1); 
        }
    }
