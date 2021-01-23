    //assuming this line correctly locates the table we are interested in
    IWebElement id = driver.FindElement(union ((By.Id(id1),By.Id(id2)); 
    //select all the td  elements containing the span with class="tennis-serve" in the above table
    //the starting '.' looks for descendants of only the context node 'id' 
    //if you want all serving players, use FindElements
    var servers = id.FindElements(By.XPath(".//span[@class='tennis-serve']/..")); 
    foreach(var s in servers)
    {
        string servingBy = s.GetAttribute("class"); 
        Console.WriteLine(servingBy);
    }
