    public static class EncodingExtensions
    {
        public static int GetByteCount(this Encoding encoding, string s, int index, int count)
        {
            var output = 0;
            var end = index + count;
            var charArray = new char[1];
            for (var i = index; i < end; i++)
            {
                charArray[0] = s[i];
                output += Encoding.UTF8.GetByteCount(charArray);
            }
            return output;
        }
    }
