    static byte[] ByteArrayFromString(string s)
        {
            int length = s.Length / 2;
            byte[] numArray = new byte[length];
            if (s.Length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    numArray[i] = byte.Parse(s.Substring(2 * i, 2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
                }
            }
            return numArray;
        }
