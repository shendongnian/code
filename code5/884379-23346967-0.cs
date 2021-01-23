    <li>
       <a class='track-visit-website' href='abc1'>Anchor1</a>
    </li>
    <li>
       <a class='track-visit-website'>Anchor 2</a>
    </li> 
    <li> 
    </li>
---
    var hoteleWebsiteDoc = (from element in doc.DocumentNode.Descendants("a")
                            where element.ParentNode.Name.Equals("li") && 
                            element.Attributes.Contains("class") &&
                            element.Attributes.Contains("href") &&
                            element.Attributes["class"].Value.Equals("track-visit-website")
                            select new
                                     {
                                       URL = element.Attributes["href"].Value
                                     }).ToList();
    foreach (var obj in hrefsList)
    {
       Console.WriteLine(obj.URL);
    }
