    public static class MyExtensions
    {
        public static string CutStringAt(this string s, int length)
        {
            int len = s.Length;
            if (len > length)
            {
                int pos = 0;
                StringBuilder sb = new StringBuilder();
                while (pos < len)
                {
                    if ((len - pos) < length)
                    {
                        int left = len - pos;
                        sb.AppendLine(s.Substring(pos, left).Trim());
                        pos += left;
                    }
                    else
                    {
                        sb.AppendLine(s.Substring(pos, length).Trim());
                        pos += length;
                    }
                }
                s = sb.ToString();
            }
            return s;
        }
    }
