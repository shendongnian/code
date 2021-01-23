    static void Main(string[] args)
    {
        List<string> myList = new List<string>();
        myList.Add("A");
        myList.Add("B");
        myList.Add("C");
        myList = myList.Select(x => Modify(x)).ToList();
    }
    private static string Modify(string input)
    {
        if (input == "A")
        {
            return "N";
        }
        else if (input == "B")
        {
            return "X";
        }
        else
        {
            return input;
        }
    }
