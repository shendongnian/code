    {
        var decoder = new VISCIIDecoder();
        var encoder = new VISCIIEncoder();
        // Some characters that are part of the VISCII character set/aren't part of the VISCII character set
        // Illegal characters are replaced with ?
        string str = "OK:ABCD1234!~|OK:\x00\x01\x03\x04\x7F|OK:ẲẴẪỶỸỴẠỮ|KO:\x02\x05\x06§|KO:\U0001F602|KO:\U000100000|KO:\uD800\uD800|KO:\uDBFF\uDBFF|KO:\uD800";
        char[] chars = str.ToCharArray();
        var byteCount = encoder.GetByteCount(chars, 0, chars.Length, true);
        var bytes = new byte[byteCount];
        var res = encoder.GetBytes(chars, 0, chars.Length, bytes, 0, true);
        int charCount = decoder.GetCharCount(bytes, 0, bytes.Length);
        var chars2 = new char[charCount];
        var res2 = decoder.GetChars(bytes, 0, bytes.Length, chars2, 0, true);
        var str2 = new string(chars2);
    }
    {
        var encoding = new VISCIIEncoding();
        // Some characters that are part of the VISCII character set/aren't part of the VISCII character set
        // Illegal characters are replaced with ?
        string str = "OK:ABCD1234!~|OK:\x00\x01\x03\x04\x7F|OK:ẲẴẪỶỸỴẠỮ|KO:\x02\x05\x06§|KO:\U0001F602|KO:\U000100000|KO:\uD800\uD800|KO:\uDBFF\uDBFF|KO:\uD800";
        var bytes = encoding.GetBytes(str);
        var str2 = encoding.GetString(bytes);
    }
