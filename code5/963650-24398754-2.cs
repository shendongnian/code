    public static bool IsCompletePacket(string s)
    {
        switch (s[0])
        {
            case 'A':
                return s.Length == 5;
            case 'B':
                return s.Length == 6;
            case 'C':
                return s.Length == 7;
            default:
                throw new ArgumentException("Packet must begin with a letter");
        }
    }
