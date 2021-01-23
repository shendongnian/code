    if (page.ispostback)
    {
         string parameter = Request["__EVENTARGUMENT"];
         string[] allParams = parameter.Split('|');
         string val = Request.Params.Get("__EVENTTARGET");
    }
