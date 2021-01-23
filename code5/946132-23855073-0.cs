    HtmlGenericControl li = new HtmlGenericControl("li");                    
    panelWrapper.Controls.Add(li);
    var checkbox = new CheckBox();
    
    checkbox.ID = "chk" + exemptionId;
    li.Controls.Add(checkbox);
