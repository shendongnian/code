    void Main()
    {
        string str = "Amit Kumar";
        int c = 0;
        while(str != "")
        {
            str = str.Substring(1);
            c++;
        }
        Console.WriteLine(c);
        Console.ReadLine();
    }
