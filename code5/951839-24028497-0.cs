    XslCompiledTransform transform = new XslCompiledTransform ();
    // Optional parameter list - from the article you linked
    XsltArgumentList parameters = new XsltArgumentList ();
    parameters.AddParam ("nSkipRows", "", "1"); 
    parameters.AddParam ("nWorksheet", "", "1"); // and so one (these will copy values to top-level correspondent `<xsl:param>` elements in the stylesheet, if they exist)
    transform.Load (xslFileName);
    StringWriter s = new StringWriter ();
    transform.Transform (xmlFileName, parameters, s); // this line does the transformation
    Console.WriteLine ("Result: " + s.ToString ()); // here just printing out the result
