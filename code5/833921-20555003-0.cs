    private static void PrintObject(IEnumerable<HtmlElement> propertyElements)
    {
        Console.WriteLine("---------------------------------");
        foreach (HtmlElement element in propertyElements)
        {
            Console.WriteLine(element.OuterHtml);
            //or
            Console.WriteLine(element.Name);
            //or
            Console.WriteLine(element.InnerHtml);
            //or
            Console.WriteLine(element.TagName);
        }
        Console.WriteLine("---------------------------------");
    }
