    static void Main(string[] args)
    {
        Console.WriteLine(FormatTime(DateTime.Now, false));
        Console.WriteLine(FormatTime(DateTime.Now, true ));
        Console.WriteLine(FormatTime(DateTime.Now, "'"  ));
        Console.WriteLine(FormatTime(DateTime.Now, "<hr />"));
    }
    static string FormatTime(DateTime date, bool isHtml)
    {
        return FormatTime(date, isHtml ? "<br />" : Environment.NewLine);
    }
    static string FormatTime(DateTime date, string separator)
    {
        return date.ToString(String.Format("hh'{0}'tt",
                  separator.Replace("'", "\\'")), new CultureInfo("EN-US"));
    }
