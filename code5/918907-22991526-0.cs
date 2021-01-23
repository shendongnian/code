    const string menu = // I've hardcoded tabs and newlines as SO formats these out.
        "GROUP\r\n" +
        "MENU1\r\n" +
        "\tSUBMENU11\r\n" +
        "\t\tSUBSUBMENU111\r\n"+
        "\t\t\tSUBSUBMENU1111\r\n" +
        "\tSUBMENU12\r\n"+
        "MENU2\r\n" +
        "\tSUBMENU21\r\n"+
        "\t\tSUBSUBMENU211";
    var sr = new StringReader(menu); // Obviously use a TextReader
    var lines = sr.ReadToEnd()
                  .Split(new[] { Environment.NewLine },
                         StringSplitOptions.RemoveEmptyEntries);
    var indentedLines =
        lines
            .Skip(1) // Group isn't part of the menu
            .Select(
            _ => new Tuple<string, int>( // Remove whitespace
                Regex.Replace(_, @"\s+", ""), 
                _.Split(new[] { '\t' }).Count())) // Count the tabs
          .ToList();
    var doc = new XDocument();
    doc.Add(new XElement("group", // Add the root group
               new XAttribute("id", lines[0].Trim()),
               new XAttribute("label", lines[0].Trim()),
               BuildTree(indentedLines, 1, String.Empty))); // Add the top lvl nodes
