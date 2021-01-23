    public static char[] Note = "hello".ToCharArray();
    public static char[] Newspaper = "ahrenlxlpoz".ToCharArray();
    foreach (char c in Note) //check each character of Note
    {
        if (Newspaper.Contains(c))
        {
            Console.Write(c); //it will display hello
        }
    }
