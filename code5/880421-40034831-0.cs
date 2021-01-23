    public static class CharArrayExtensions
    {
        public static char[] SubArray(this char[] input,int startIndex, int length)
        {
            List<char> result= new List<char>();
            for (int i = startIndex; i < length; i++)
            {
                result.Add(input[i]);
            }
            return result.ToArray();
        }
    }
