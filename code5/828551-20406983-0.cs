    static void Main(string[] args)
    {
        char cPound = '£';
        byte bPound = (byte)cPound; //not really valid
        string sPound = "" + cPound;
        byte[] poundBytes = Encoding.GetEncoding("UTF-8").GetBytes(sPound);
        string poundFromBytes = Encoding.GetEncoding("UTF-8").GetString(pountBytes);
        Console.WriteLine(poundFromBytes);
        Console.ReadKey(True);
    }
