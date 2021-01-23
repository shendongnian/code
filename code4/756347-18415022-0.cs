    static void Main(string[] args)
    {
        int x = 0;
        string userInput;
        Console.WriteLine("Please enter the 10 digit telephone number. ");
        userInput = Console.ReadLine();
        Dictionary<string,string> dict = new Dictionary<string,string>();
        dict.Add("1","1"); 
        dict.Add("ABC2","2");
        dict.Add("DEF3","3");
        dict.Add("GHI4","4");
        dict.Add("JKL5","5");
        dict.Add("MNO6","6");
        dict.Add("PQR7","7");
        dict.Add("STU8","8");
        dict.Add("VWXYZ9","9");
        dict.Add("0","0");
        userInput = string.Join("",userInput.Select(c=>dict.First(k=>k.Key.Contains(c)).Value).ToArray());
        Console.WriteLine(userInput);
    }
