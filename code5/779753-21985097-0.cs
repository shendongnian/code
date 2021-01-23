    DataTable x = ...  // x is DataTable Name
    int index = ...    // index is the column sequence no.
    string col = x.Columns[index].Columnname.ToString().Trim();    
    if (!System.Text.RegularExpressions.Regex.IsMatch(col, "^[A-Z]{1}[0-9]*"))
       // do something
