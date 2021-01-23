    private char[] TABLEALL = new char[29750];
    public string this[int index]
    {
        get
        {
            string s = new string(TABLEALL, index * 85, 85);
            // if you want to keep the trailing spaces, then just return s.
            return s.Trim();
        }
        set
        {
            if (value == null) return;
            // make sure the string is exactly 85 characters long,
            // truncating or padding as necessary.
            int len = Math.Max(value.Length, 85);
            string padded = value.Substring(0, len).PadRight(85);
            // get the characters
            char[] chars = padded.ToCharArray(0, 85);
            // and copy them to the proper place
            Array.Copy(chars, 0, TABLEALL, index * 85, chars.Length);
        }
    }
