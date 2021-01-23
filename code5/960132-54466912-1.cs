    //assign expression
    var expression = string.Empty;
    expression = expression + " + ',' + " + tagColumn;
    dtContact.Columns["Tag_All"].Expression = expression;
    //Clone datatable structure
    DataTable dtNew = dtContact.Clone();
    //Remove expression from a specific column
    dtNew.Columns["Tag_All"].Expression = "";
    //Merge data with the new Table
    dtNew.Merge(dtContact);
    dtContact.Dispose();
    //Now you can remove the column used within the expression
    dtNew.Columns.RemoveAt(2);
    
    
