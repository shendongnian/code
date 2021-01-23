    private static void ReadTheSummarys()
    {
      XmlReader xmlReader = XmlReader.Create("Test.xml");
      bool isSummary = false;
      while (xmlReader.Read())
    {
    //checks if the current node is a summaray
    if (xmlReader.Name == "summary")
    {
      isSummary = true;
      continue;
    }
    if (isSummary)
    {
      //Replace and trim for pure Comments without spaces and linefeeds
      string summary = xmlReader.Value.Trim().Replace("\n", string.Empty);
      if (summary != string.Empty)
      {
        //Writes the pure comment for checking
        Console.WriteLine(summary);           
      }
    isSummary = false;
    }
    }
    }
