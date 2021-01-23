    //xxclass
    public string Method1(string text)
    {
       return text;
    }
    
    public static class stringExtension
    {
        public static string Method2(this string s, int num1)
        {
           return s + num1;
        }
    }
    
    
    Method1("sample string").Method2(12345).ToString();
