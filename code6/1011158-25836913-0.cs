    public static char[] Note = "hello".ToCharArray();
    public static char[] Newspaper = "ahrenlxlpoz".ToCharArray();
    Array.Sort(Note);
    Array.Sort(Newspaper);
    string strNote = new string(Note); //change Note to string
    foreach (char c in strNote) //check each character of Note
    {
        if (Newspaper.Contains(c))
        {
            Console.Write(c);
        }
    }
