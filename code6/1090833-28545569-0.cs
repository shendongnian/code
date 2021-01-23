    public void ScrollTo(int xPosition = 0, int yPosition = 0)
    {
    	var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
    	JavaScriptExecutor.ExecuteScript(js);
    }
    
    public IWebElement ScrollToView(By selector)
    {
    	var element = WebDriver.FindElement(selector);
    	ScrollToView(element);
    	return element;
    }
    
    public void ScrollToView(IWebElement element)
    {
    	if (element.Location.Y > 200)
    	{
    		ScrollTo(0, element.Location.Y - 100); // Make sure element is in the view but below the top navigation pane
    	}
    
    }
