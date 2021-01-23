    public string calcXor(string a, string b)
    {
      //String to binary
      byte[] ab = ConvertToBinary(a);
      byte[] bb = ConvertToBinary(b);
      //(XOR)
      byte[] cb = a^b  
      return cb.ToString();
    }
    public static byte[] ConvertToBinary(string str)
    {
      System.Text.ASCIIEncoding  encoding = new System.Text.ASCIIEncoding();
      return encoding.GetBytes(str);
    }
