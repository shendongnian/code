    {
        var decoder = new VISCIIDecoder();
        var encoder = new VISCIIEncoder();
        string str = "ABCabc€Ạ\U00010000"; // € isn't a VISCII character, Ạ is, \U00010000 is a non-BMP character
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
        string str = "ABCabc€Ạ\U00010000"; // € isn't a VISCII character, Ạ is, \U00010000 is a non-BMP character
        var bytes = encoding.GetBytes(str);
        var str2 = encoding.GetString(bytes);
    }
