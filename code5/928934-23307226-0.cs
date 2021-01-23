    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(htmlSource);
    string shipCostHtml = doc.DocumentNode.SelectSingleNode("//span[@class='plusShippingText']").InnerText;
    string shipCost = System.Net.WebUtility.HtmlDecode(shipCostHtml);
    shipCost = shipCost.Trim(' ', '+', '\xa0');
