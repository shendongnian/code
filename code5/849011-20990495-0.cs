    public static bool IsInputContainNonGSM7BitCharacterSet(string value)
    {
        string GSM_7_BIT_CHARACTER_SET = " @£$¥èéùìòÇØøÅåΔ_ΦΓΛΩΠΨΣΘΞ^{}\\[~]|€ÆæßÉ!\"#¤%&'()*+,-./0123456789:;<=>?¡ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÑÜ§¿abcdefghijklmnopqrstuvwxyzäöñüà";
        char letter = default(char);
    
        for (int i = 0; i < value.Length; i++)
        {
            letter = value[i];
    
            if (GSM_7_BIT_CHARACTER_SET.IndexOf(letter) == -1)
            {
                return true;
            }
        }
    }
