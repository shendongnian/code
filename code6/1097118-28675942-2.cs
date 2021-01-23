    /// <summary>
    /// Only the Read methods are supported!
    /// </summary>
    public class ReplacingStreamReader : StreamReader
    {
        public ReplacingStreamReader(string path)
            : base(path)
        {
        }
        public Func<char, string> ReplaceWith { get; set; }
        protected char[] RemainingChars { get; set; }
        protected int RemainingCharsIndex { get; set; }
        public override int Read()
        {
            int ch;
            if (RemainingChars != null)
            {
                ch = RemainingChars[RemainingCharsIndex];
                RemainingCharsIndex++;
                if (RemainingCharsIndex == RemainingChars.Length)
                {
                    RemainingCharsIndex = 0;
                    RemainingChars = null;
                }
            }
            else
            {
                ch = base.Read();
                if (ch != -1)
                {
                    string replace = ReplaceWith((char)ch);
                    if (replace == null)
                    {
                        // Do nothing
                    }
                    else if (replace.Length == 1)
                    {
                        ch = replace[0];
                    }
                    else
                    {
                        ch = replace[0];
                        RemainingChars = replace.ToCharArray(1, replace.Length - 1);
                        RemainingCharsIndex = 0;
                    }
                }
            }
            return ch;
        }
        public override int Read(char[] buffer, int index, int count)
        {
            int res = 0;
            // We leave error handling to the StreamReader :-)
            // We handle only "working" parameters
            if (RemainingChars != null && buffer != null && index >= 0 && count > 0 && index + count <= buffer.Length)
            {
                int remainingCharsCount = RemainingChars.Length - RemainingCharsIndex;
                res = Math.Min(remainingCharsCount, count);
                Array.Copy(RemainingChars, RemainingCharsIndex, buffer, index, res);
                RemainingCharsIndex += res;
                if (RemainingCharsIndex == RemainingChars.Length)
                {
                    RemainingCharsIndex = 0;
                    RemainingChars = null;
                }
                if (res == count)
                {
                    return res;
                }
                index += res;
                count -= res;
            }
            while (true)
            {
                List<char> sb = null;
                int res2 = base.Read(buffer, index, count);
                if (res2 == 0 || ReplaceWith == null)
                {
                    return res;
                }
                int j = 0;
                for (int i = 0; i < res2; i++)
                {
                    char ch = buffer[index + i];
                    string replace = ReplaceWith(ch);
                    if (sb != null)
                    {
                        if (replace == null)
                        {
                            sb.Add(ch);
                        }
                        else
                        {
                            sb.AddRange(replace);
                        }
                    }
                    else if (replace == null)
                    {
                        buffer[j] = ch;
                        j++;
                    }
                    else if (replace.Length == 1)
                    {
                        buffer[j] = replace[0];
                        j++;
                    }
                    else if (replace.Length == 0)
                    {
                        // We do not advance
                    }
                    else
                    {
                        sb = new List<char>();
                        sb.AddRange(replace);
                    }
                }
                res2 = j;
                if (sb != null)
                {
                    int res3 = Math.Min(sb.Count, count - res2);
                    sb.CopyTo(0, buffer, index + res2, res3);
                    if (res3 < sb.Count)
                    {
                        RemainingChars = new char[sb.Count - res3];
                        RemainingCharsIndex = 0;
                        sb.CopyTo(res3, RemainingChars, 0, RemainingChars.Length);
                    }
                    res += res3;
                }
                else
                {
                    res2 = j;
                    // Can't happen if sb != null (at least a character must
                    // have been added)
                    if (res2 == 0)
                    {
                        continue;
                    }
                }
                res += res2;
                return res;
            }
        }
    }
