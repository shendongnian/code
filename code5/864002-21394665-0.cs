    string myid = string.Empty; 
    for (int i = 0; i < gv_enfant.Rows.Count; i++) 
    { 
        var chbox = gv_enfant.Rows[i].Cells[0].FindControl("CheckBoxenfant") as CheckBox; 
        var codeenfant = gv_enfant.Rows[i].Cells[0].FindControl("codeenfant") as HiddenField
        if(chbox != null && codeenfant  != null)
        { 
            if (chbox.Checked) 
            { 
                myid = codeenfant.Value; 
            } 
        }
    }
