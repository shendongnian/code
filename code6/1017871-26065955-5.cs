    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(text);
    var node1A = doc.DocumentNode.SelectSingleNode("//table[1]//table[1]");
    string content1A = node1A.InnerText;
    Console.WriteLine(content1A);
    var node2C = doc.DocumentNode.SelectSingleNode("//table[2]//table[3]");
    string content2C = node2C.InnerText;
    Console.WriteLine(content2C);
