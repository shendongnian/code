        static void Main(string[] args)
    {
         
        Console.WriteLine("Please provide a list of characters");
        string Charactersinput  = Console.ReadLine();
        Console.WriteLine("Please provide the search character");
        char Searchinput = Console.ReadKey().KeyChar;
        Console.WriteLine("");
        
        List<char> ListOfCharacters = new List<char>();
        //fill the list of characters with the characters from the string
        // Or empty it, if th esearch charcter is found
        for (int i = 0; i < Charactersinput .Length;  i++)
        {
            if (Searchinput == Charactersinput[i])
            {
                ListOfCharacters.Clear();
            }
            else
            ListOfCharacters.Add(Charactersinput [i]);
        }
        //get your string back together
        string Result = String.Concat(ListOfCharacters);
       
        Console.WriteLine("Here's a list of all characters after processing: {0}", Result);
        Console.ReadLine();
       
    }
