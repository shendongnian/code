    public static TimeSpan Parse(string s)
    {
        long seconds = 0;
        long current = 0;
        int len = s.Length;
        for (int i=0; i<len; ++i)
        {
            char c = s[i];
            if (char.IsDigit(c))
            {
                current = current * 10 + (int)char.GetNumericValue(c);
            }
            else if (char.IsWhiteSpace(c))
            {
                continue;
            }
            else
            {
                long multiplier;
                switch (c)
                {
                    case 's': multiplier = 1; break;      // seconds
                    case 'm': multiplier = 60; break;     // minutes
                    case 'h': multiplier = 3600; break;   // hours
                    case 'd': multiplier = 86400; break;  // days
                    case 'w': multiplier = 604800; break; // weeks
                    default:
                        throw new FormatException(
                            String.Format(
                                "'{0}': Invalid duration character {1} at position {2}. Supported characters are s,m,h,d, and w", s, c, i));
                }
                seconds += current * multiplier;
                current = 0;
            }
        }
        if (current != 0)
        {
            throw new FormatException(
                String.Format("'{0}': missing duration specifier in the end of the string. Supported characters are s,m,h,d, and w", s));
        }
        return TimeSpan.FromSeconds(seconds);
    }
