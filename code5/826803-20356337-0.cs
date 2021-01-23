    ...
    TextBox t = new TextBox();
    t.ID = "textBoxName" + num.ToString();
    div.Controls.Add(ipLabel);
    div.Controls.Add(t);
    
    var rfv = new RequiredFieldValidator();
    rfv.ID = "RequiredFieldValidator" + num;
    rfv.ControlToValidate = t.ID;
    rfv.ErrorMessage = num + " is required.";
    div.Controls.Add(rfv);
    
    phDynamicTextBox.Controls.Add(div);
    ...
