    public static string StrToHex(string strMessage)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(strMessage);
        string strHex = BitConverter.ToString(byteArray);
        strHex = strHex.Replace("-", "");
        return strHex;
    }
