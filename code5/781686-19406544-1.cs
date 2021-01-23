      public static class Validator // todo: doesn't belong in the controllers directory ?
      {
        public static List<JsonError> CheckModelErrors(System.Web.Mvc.ModelStateDictionary modelstate)
        {
          List<JsonError> errorlist = new List<JsonError>();
          if (modelstate != null && modelstate.Values != null)
          {
            foreach (var m in modelstate.Values)
            {
              if (m.Errors != null)
              {
                foreach (var e in m.Errors)
                {
                  errorlist.Add(new JsonError() { ErrorMessage = e.ErrorMessage ?? "" });
                }
              }
            }
          }
          return errorlist;
        }
      }
