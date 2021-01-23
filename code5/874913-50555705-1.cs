    List<IWebElement> el = new List<IWebElement>(); el.AddRange(driver.FindElements(By.CssSelector("*")));
    
    List<string> ag= new List<string>();
    for (int b = 0; b < el.Count; b++)
    {                    
        ag.Add(el[b].GetAttribute("outerHTML"));
    }
