    protected void DropDownListAddNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
     List<string> sessionList = GetSessionVariable();
     sessionList.Add(DropDownListAddNumber.Items.FindByValue
                     (DropDownListAddNumber.SelectedValue));
    }
    
    // you can access the selected values from the list
    // if sessionList.Any(), then sessionList.Last() will contain 
    // the last selected value.. etc.
    
    private List<string> GetSessionVariable()
    {
     var list = Session["SelectionValuesList"] as List<string>;
    
     if (list == null)
     {
      list = new List<string>();
      Session["SelectionValuesList"] = list;
     } 
    
     return list;
    }
