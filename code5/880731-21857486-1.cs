    var fragment = @"<Something>abc</Something>
    <Another>def</Another>
    <Other>ghi</Other>";
    
    var xDoc = XDocument.Parse("<Root>" + fragment + "</Root>");
    
    xDoc.Descendants("Another").First().Value = "Jabberwocky";
    xDoc.Element("Root").Add(new XElement("Omega", "Man"));
    
    var fragOut = 
       string.Join(Environment.NewLine, xDoc.Descendants("Root")
                                            .Elements()
    										.Select (ele => ele.ToString()));
    
    Console.WriteLine (fragOut);
    /* Prints out
    <Something>abc</Something>
    <Another>Jabberwocky</Another>
    <Other>ghi</Other>
    <Omega>Man</Omega>
    */
