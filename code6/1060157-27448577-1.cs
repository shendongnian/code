    public static string UrlName(this Type controller)
    {
      var name = controller.Name;
      return name.EndsWith("Controller") ? name.Substring(0, name.Length - 10) : name;
    }
