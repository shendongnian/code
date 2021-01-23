    class Program
    {
        static void Main(string[] args)
        {
            HtmlDocument document = new HtmlDocument();
            document.Load("Demo.html");
            HtmlNode mainDiv = document.DocumentNode.SelectSingleNode("//div[@id='mainDiv']");
            foreach (var child in mainDiv.Descendants())
            {
                if (child.Attributes.Any(att=> att.Name == "class"))
                {
                    child.Attributes["class"].Value = "data-attr";
                }
                else
                {
                    child.Attributes.Add("class", "data-attr");
                }
            }
            document.Save("Demo.html");
        }
    }
