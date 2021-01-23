    foreach (HtmlNode node in document.DocumentNode.SelectNodes("//table/tr/td/font"))
    {
        if (node.InnerText == "Freq PolMode" || node.InnerText == "SR-FEC")
        {
            sXPath = node.ParentNode.ParentNode.ParentNode.XPath + "//tr";
            HtmlNodeCollection rows = document.DocumentNode.SelectNodes(sXPath);
            for (int i = 0; i < rows.Count; i++)
            {
                sXPath = rows[i].XPath + "/td[2]/font[1]";
                htmlNode = document.DocumentNode.SelectSingleNode(sXPath);
                if (htmlNode != null)
                {
                    if (htmlNode.InnerText.Length >= 7)
                    {
                        string freq = htmlNode.InnerText.Substring(0, 5);
                        if (int.TryParse(freq, out intFrequency) == true)
                        {
                            string pol = htmlNode.InnerText.Substring(6, 1);
                            if (pol == "H")
                                bPolarity = false;
                            else if (pol == "V")
                                 bPolarity = true;
                         }
                     }
                 }
    
                 sXPath = rows[i].XPath + "/td[3]/font[1]";
                 htmlNode = document.DocumentNode.SelectSingleNode(sXPath);
                 if (htmlNode != null)
                 {
                     if (htmlNode.InnerText.Length >= 5)
                     {
                         string sr = htmlNode.InnerText.Substring(0, 5);
                         if (int.TryParse(sr, out intSymbolRate) == false)
                         {
                             sr = htmlNode.InnerText.Substring(0, 4);
                             int.TryParse(sr, out intSymbolRate);
                         }
                     }
                 }
             }
             break;
         }
     }
