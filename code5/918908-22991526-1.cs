    IEnumerable<XElement> BuildTree(
         IList<Tuple<string, int>> indentedLines, 
         int indentLevel, String parentNode)
    {
        Func<string, string> getNodeParent =
            node =>
                {
                    var line = indentedLines.First(_ => _.Item1 == node);
                    for (var index = indentedLines.IndexOf(line); index >= 0; index --)
                    {
                        if (indentedLines[index].Item2 < line.Item2)
                        {
                            return indentedLines[index].Item1;
                        }
                    }
                    return String.Empty; // has no parent
                };
        foreach (var line in indentedLines.Where(_ => _.Item2 == indentLevel 
                 && getNodeParent(_.Item1) == parentNode))
        {
            yield return new XElement("menu",
                                      new XAttribute("id", line.Item1),
                                      new XAttribute("label", line.Item1),
                                      new XAttribute("size", "normal"),
                                      BuildTree(indentedLines, indentLevel + 1, line.Item1));
        }
    }
