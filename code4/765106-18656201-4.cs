    static void Main(string[] args)
    {
        string foo = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec blandit ligula dolor, tristique.";
        Console.Write(Truncate(foo, 20));
        Console.Read();
    }
    public static string Truncate(string text, int maxlength)
    {
         maxlength = maxlength - 2;//allow space for '- '
         string truncated = string.Empty;
         int lastSpace = 0;
         if (text.Length > maxlength)
         {
             string temp = text.Substring(0, maxlength);
             lastSpace = temp.LastIndexOf(" ");
             truncated = temp.Substring(0, lastSpace);        
         }
         else
         {
             return text;
         }
         return truncated.Trim().Insert(truncated.Length, "- ") + text.Substring(lastSpace);
    }
