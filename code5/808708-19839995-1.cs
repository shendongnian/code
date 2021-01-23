    string x = "éí&";
    string encoded = System.Web.HttpUtility.HtmlEncode(x);
    Console.WriteLine(encoded);  //&#233;&#237;&amp;
    string decoded = System.Web.HttpUtility.HtmlDecode(encoded);
    Console.WriteLine(decoded);  //éí&
