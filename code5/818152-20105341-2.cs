    // Assuming you have the row object, either from e.Row or 
    // finding the parent or grandparent of the click event sender
    GridViewRow theGridViewRow;
    // Find the application number label control in the row
    var theApplicationNumberLabel = theGridViewRow.FindControl("LabelApplicationNumber") as Label;
    // Make sure we found the label before we try to use it
    if(theApplicationNumberLabel != null)
    {
        // Get the value
        string theApplicationNumber = theApplicationNumberLabel.Text;
    }
    // Do similar logic for each control in the row you want the value of here
