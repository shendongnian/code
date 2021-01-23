    public void Save()
    {
      int i = 0;
      foreach (var item in _stack)
      {
        Settings.Default["com" + i++] = item;
      }
    }
    public void Load()
    {
      for (int i = 0; i < Limit; i++)
      {
        _stack.Add((T)Settings.Default["com" + i++]);
      }
    }
