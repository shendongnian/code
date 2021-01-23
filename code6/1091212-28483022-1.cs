      public ActionResult Index(AdFilter filter)
      {
         string parameters = "?";
         foreach (var item in filter.tag)
            {
                parameters += string.Format("tag={0}&", item);
            }
         //trimming the last "&"
         parameters = parameters.TrimEnd(parameters[parameters.Length - 1]);
         string url = Url.Action("DoFilter") + parameters;
         
      }
