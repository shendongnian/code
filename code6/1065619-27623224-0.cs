    private static void Main()
    {
         HtmlDocument html = new HtmlDocument();
         html.LoadHtml(@"<span style=""abc"">Welcome</span><span style=""xyz"">to C#</span>");
         Console.WriteLine(html.DocumentNode.InnerText);
         Console.Read();
    }
