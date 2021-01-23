    private const string CharList = "0123456789abcdefghijklmnopqrstuvwxyz";
    
    public static String Base36Encode(long input, char paddingChar, int totalWidth)
    {
        char[] clistarr = CharList.ToCharArray();
        var result = new Stack<char>();
    
        while (input != 0)
        {
            result.Push(clistarr[input % 36]);
            input /= 36;
        }
    
        return new string(result.ToArray()).PadLeft(totalWidth, paddingChar).ToUpper();
    }
