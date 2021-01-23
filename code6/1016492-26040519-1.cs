    public HtmlControl child()
    {
        //First, we create an empty HtmlControl to return.
        HtmlControl result = new HtmlControl()
         
        //Specify the parent and get a collection of the children (this only goes one level, 
        //   so if you have to go deeper, you'll have to nest your foreach loops and get
        //   children of the children, etc.
        HtmlControl parent = new HtmlControl(browser);
        parent.SearchProperties["id"] = "[my id]";
        UITestControlCollection children = parent.GetChildren();
  
        foreach (UITestControl child in children)
        {
            // If the child has the text you're looking for, then assign it to the result
            // object and break the loop.
            if (child.GetProperty("InnerText").ToString().Equals(searchTerm))
            {
                result = (HtmlControl)child;
                break;
            }
        }
        return result;
    }
