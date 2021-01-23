    var input = "http://www.mytestsite.com/TesPage.aspx?pageid=32&LangType=1033&emailAddress=myname%40gmail.com";
    var queryString = new Uri(input).Query;
    
    var parsed = HttpUtility.ParseQueryString(queryString);
    
    var attribute = new EmailAddressAttribute();
    var emails = new List<string>();
    foreach (var key in parsed.Cast<string>())
    {
        var value = parsed.Get(key);
        if (attribute.IsValid(value))
            emails.Add(value);
    }
    Console.WriteLine(String.Join(", ", emails)); // prints: myname@gmail.com
