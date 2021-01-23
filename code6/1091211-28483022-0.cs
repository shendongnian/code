      public ActionResult Index(AdFilter filter)
      {
         string parameters = "?";
         foreach (var item in filter.tag)
            {
                parameters += string.Format("tag={0}", item);
            }
         string url = Url.Action("DoFilter") + parameters;
         
      }
