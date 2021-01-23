    System.Web.Mvc.RazorViewEngine rve = (RazorViewEngine)ViewEngines.Engines
      .Where(e=>e.GetType()==typeof(RazorViewEngine))
      .FirstOrDefault();
    string[] additionalPartialViewLocations = new[] { 
      "~/Views/GeneralTemplates/{0}.cshtml"
    };
    if(rve!=null)
    {
      rve.PartialViewLocationFormats = rve.PartialViewLocationFormats
        .Union( additionalPartialViewLocations )
        .ToArray();
    }
