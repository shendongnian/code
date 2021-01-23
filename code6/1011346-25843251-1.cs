     LinkButton _singleClickButton = row.FindControl("lnkBtnClk") asLinkButton;
 
     string _jsSingleClick = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
 
     e.Row.Attributes.Add("onclick", _jsSingleClick);
 
 
 
