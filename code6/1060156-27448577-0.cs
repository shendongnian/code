    public static string Name(this Controller controller) {
      var name = nameof(controller);
      if (name.EndsWith("Controller")) return name.Substring(0, name.Length - 10);
      return name;
    }
