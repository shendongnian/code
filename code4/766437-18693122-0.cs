    public class UTF8NoZero : UTF8Encoding
    {
        public override Decoder GetDecoder()
        {
            return new MyDecoder();
        }
    }
    public class MyDecoder : Decoder
    {
        public Encoding UTF8 = new UTF8Encoding();
        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            return UTF8.GetCharCount(bytes, index, count);
        }
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            int count2 = UTF8.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
            int i, j;
            for (i = charIndex, j = charIndex; i < charIndex + count2; i++)
            {
                if (chars[i] != '\0')
                {
                    chars[j] = chars[i];
                    j++;
                }
            }
            for (int k = j; k < charIndex + count2; k++)
            {
                chars[k] = '\0';
            }
            return count2 + (i - j);
        }
    }
