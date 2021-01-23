    static void Main(string[] args)
    {
        string foo = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec blandit ligula dolor, tristique.";
        Console.Write(Truncate(foo, 20));
        Console.Read();
    }
    public static string Truncate(string text, int length)
    {
        int index = text.Length;
        while (index > 0)
        {
            foo = text.Insert(index, "- ");
            index -= length;
        }
        return text;
    }
