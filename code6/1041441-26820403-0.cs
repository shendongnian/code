    public void SwallowExceptions(Action action)
    {
      try
      {
        action();
      }
      catch
      {
      }
    }
    public string DoSomething()
    {
      string data = "TerribleIdea";
      string result = null;
      SwallowExceptions(() => result = data.Substring(0, 10000));
      return result;
    }
