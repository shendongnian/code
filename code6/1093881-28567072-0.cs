    public string Key
    {
      get{
        List<string> l = new List<string>{One, Two};
        l = l.OrderBy(x => x).ToList();
        return "Key_" + string.Join("_", l);
      }
    }
