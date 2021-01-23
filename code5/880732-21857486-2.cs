    var fragment = @"<Something>abc</Something>
    <Another>def</Another>
    <Other>ghi</Other>";
    
    var xDoc = XDocument.Parse("<TempRoot>" + fragment + "</TempRoot>");
    
    xDoc.Descendants("Another").First().Value = "Jabberwocky";
    xDoc.Root.Add(new XElement("Omega", "Man"));
    
    var fragOut = 
       string.Join(Environment.NewLine, xDoc.Root
                                            .Elements()
    										.Select (ele => ele.ToString()));
    
    Console.WriteLine (fragOut);
    /* Prints out
    <Something>abc</Something>
    <Another>Jabberwocky</Another>
    <Other>ghi</Other>
    <Omega>Man</Omega>
    */
