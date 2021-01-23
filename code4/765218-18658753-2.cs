    public IList<Title> Checkboxes
    {
        get
        {
           CheckBox chkEPS;
           CheckBox chkIMDF;
           CheckBox chkPS;
    
            IList<Title> checkedList = new List<Title>();
            foreach (GridViewRow row in gvwTitles.Rows)
            {
                chkABC = (CheckBox)row.FindControl("chkABC");
                chkABCD = (CheckBox)row.FindControl("chkABCD");
                chkABCDE = (CheckBox)row.FindControl("chkABCDE");
    			
    			
    			checkedList.Add(new Title(1 , chkABC.Checked ? true : false, chkABCD.Checked ? true : false, chkABCDE.Checked ? true : false));
    
            }            
               return checkedList;            
        }                  
    }
