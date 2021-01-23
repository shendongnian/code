    public static void ReverseString(string str)    // example str="cat"
    {
        if(str.Length > 0)
        {
            // grabs the first charactor        "c"
            char ch = str[0]; 
            // prints the last n-1 charactors in reverse order   "ta"
            ReverseString(str.Substring(1));
            // prints that last charactor      "c" leads to "tac"... Yeay!!
            Console.Write(ch);
        }
    }
