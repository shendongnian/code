    var s = "<P align=justify><STRONG>Pricings<BR></STRONG>It was another active week for names leaving the database. The week's prints consisted of two ILS, and sever ITS.</P>";
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(s);
    string result;
    var p = doc.DocumentNode.SelectSingleNode("p");
    if (p.ChildNodes.Count == 2)
        result = p.ChildNodes[1].InnerText;
