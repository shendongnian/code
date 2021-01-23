    [TestMethod]
    public void WriteIndentedText()
    {
        var result = new StringBuilder();
        using (var writer = new IndentTextXmlWriter(new StringWriter(result)){Formatting = Formatting.Indented, IndentText = true})
        {
            string text = @" Line 1
    Line 2
        Line 3  ";
            // some root
            writer.WriteStartDocument();
            writer.WriteStartElement("root");
            writer.WriteStartElement("child");
            // test auto-indenting
            writer.WriteStartElement("elementIndented");
            writer.WriteString(text);
            writer.WriteEndElement();
            // test space preserving
            writer.WriteStartElement("elementPreserved");
            writer.WriteAttributeString("xml", "space", null, "preserve");
            writer.WriteString(text);
            writer.WriteEndDocument();
        }
        Debug.WriteLine(result.ToString());
    }
