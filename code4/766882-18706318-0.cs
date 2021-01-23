    public static void ReverseString(string str)    // example str="cat"
    {
        if(str.Length > 0)
        {
            // grabs the last charactor        "t"
            char ch = str[str.Length-1]; 
            // prints the first n-1 charactors in reverse order   "ac"
            ReverseString(str.Substring(0,str.Length-2));
            // prints that last charactor      "t" leads to "act"... not quite right
            Console.Write(ch);
        }
    }
