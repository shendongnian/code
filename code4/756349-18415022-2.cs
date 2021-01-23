    static void Main(string[] args)
    {
        int x = 0;
        string userInput;
        Console.WriteLine("Please enter the 10 digit telephone number. ");
        userInput = Console.ReadLine();
        string[] s = "0,1,ABC2,DEF3,GHI4,JKL5,MNOP6,PQR7,STU8,VWXYZ9".Split(',');
        userInput = string.Join("",userInput.Select(c=>s.Select((x,i)=>new{x,i})
                                                        .First(k=>k.x.Contains(c)).i).ToArray());
        Console.WriteLine(userInput);
    }
