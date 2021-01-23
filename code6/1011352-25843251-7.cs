     LinkButton _dblClickButton = row.FindControl("lnkBtnDblClk") asLinkButton;
 
     string _jsDoubleClick = ClientScript.GetPostBackClientHyperlink(_dblClickButton, "");
 
     e.Row.Attributes.Add("ondblclick", _jsDoubleClick);
 
 
 
