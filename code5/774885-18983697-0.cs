    public static HtmlRow GetRow(this HtmlTable table, string cellContent)
    {
      if((UITestControl)table == (UITestControl)null)
        throw new ArgumentNullException("table");
      if(cellContent.Length > 80)
        cellContent = cellContent.Substring(0, 80); //Our table cells only display the first 80 chars
      //Locate the first control in the table that has the inner text that I'm looking for
      HtmlControl searchControl = new HtmlControl(table);
      searchControl.SearchProperties.Add(PropertyNames.InnerText, cellContent);
      //Did we find a control with that inner text?
      if(!searchControl.TryFind())
      {
        //If not, the control might be an HtmlEdit with the text
        HtmlEdit firstTableEdit = new HtmlEdit(table);
        //Get all of the HtmlEdits in the table
        UITestControlCollection matchingEdits = firstTableEdit.FindMatchingControls();
        //Iterate through them, see if any have the correct text
        foreach (UITestControl edit in matchingEdits)
        {
          if(cellContent == ((HtmlEdit)edit).Text)
            searchControl = (HtmlControl)edit;
        }
      }
      //We have(hopefully) found the control in the table with the text we're searching for
      //Now, we spiral up through its parents until we get to an HtmlRow
      while (!(searchControl is HtmlRow))
      {
        searchControl = (HtmlControl)searchControl.GetParent();
      }
      
      //The control we're left with should be an HtmlRow, and should be an Ancestor of a control that has the correct text
      return (HtmlRow)searchControl;
    }
