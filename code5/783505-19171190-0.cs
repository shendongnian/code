    IWebElement matchedRow = null;
    try
    {
    	foreach(var row in rows)
    	{
    		if(row.FindElements(By.XPath("td/span")).FirstOrDefault(cell => cell.Text.Trim().Equals(TableRowIdentifier)) != null)
    		{
    			matchedRow = row;
    			break;
    		}
    	}
    }
    catch (NoSuchElementException)
    {
    	//couldnot find 
    	matchedRow = null;
    }
    
    if(matchedRow !=null)
    {
    	cellValue = matchedRow.FindElement(By.XPath(string.Format("td[{0}]/span",targetCellIndex)).Text;
    }
    
    return cellValue;
