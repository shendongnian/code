    *SomeNamespace*
    public static class UrlHelpers
    {
      public static string Script<TModel>(this Nancy.ViewEngines.Razor.UrlHelpers<TModel> Self,     string Script)
      {
        var rootPath = Self.RenderContext.Context.Request.Path.TrimEnd('/');
        var scriptPath = string.Format("{0}/Scripts/{1}", rootPath, Script);
        return scriptPath;
       }
    }
