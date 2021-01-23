    Control ctrl = null;
    string target = Page.Request.Params.Get("__EVENTTARGET");
    if (!String.IsNullOrEmpty(target))
        ctrl = page.FindControl(target);
    if(ctrl == check){
         //check is the control that caused postback
    }
