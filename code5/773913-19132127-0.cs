    public static class DocFile
    {
        // magic Doc File header
        // check this for more: http://social.msdn.microsoft.com/Forums/en-US/343d09e3-5fdf-4b4a-9fa6-8ccb37a35930/developing-a-tool-to-recognise-ms-office-file-types-doc-xls-mdb-ppt-
        private const string Header = "d0cf11e0";
        public static void Save(string text, string filePath)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            int start = text.IndexOf(Header);
            if (start < 0)
                throw new ArgumentException(null, "Text does not contain a doc file.");
            int end = text.IndexOf('}', start);
            if (end < 0)
            {
                end = text.Length;
            }
            using (MemoryStream bytes = new MemoryStream())
            {
                bool highByte = true;
                byte b = 0;
                for (int i = start; i < end; i++)
                {
                    char c = text[i];
                    if (char.IsWhiteSpace(c))
                        continue;
                    if (highByte)
                    {
                        b = (byte)(16 * GetHexValue(c));
                    }
                    else
                    {
                        b |= GetHexValue(c);
                        bytes.WriteByte(b);
                    }
                    highByte = !highByte;
                }
                File.WriteAllBytes(filePath, bytes.ToArray());
            }
        }
        private static byte GetHexValue(char c)
        {
            if (c >= '0' && c <= '9')
                return (byte)(c - '0');
            if (c >= 'a' && c <= 'f')
                return (byte)(10 + (c - 'a'));
            if (c >= 'A' && c <= 'F')
                return (byte)(10 + (c - 'A'));
            throw new ArgumentException(null, "c");
        }
    }
