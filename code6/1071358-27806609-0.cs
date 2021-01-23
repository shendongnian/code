    public static byte[] StrToByteArray(string value)
    {
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        return encoding.GetBytes(value);
    }
