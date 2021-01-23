    string hexString = "0e2a0e270e310e2a0e140e350e040e230e310e1a";
    // unscramble the hex
    byte[] bytes = new byte[hexString.Length / 2];
    for(int i = 0; i < bytes.Length; i++)
    {
        bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
    }
    // convert to a string via big-endian utf-16
    string result = Encoding.BigEndianUnicode.GetString(bytes); // "สวัสดีครับ"
