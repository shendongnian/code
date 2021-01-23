     LinkButton _singleClickButton = row.FindControl("lnkBtnClk") asLinkButton;
 
     string _jsSingleClick = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
 
 
 
     ///We make the script as below format.
 
     //javascript:setTimeout("POSTBACK SCRIPT", 500)
 
     _jsSingleClick = _jsSingleClick.Insert(11, "setTimeout(\"");
 
     _jsSingleClick += "\", 500)";
 
 
 
     e.Row.Attributes.Add("onclick", _jsSingleClick);
 
 
 
