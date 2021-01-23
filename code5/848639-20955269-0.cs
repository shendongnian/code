    var en = SomeStringSource.GetEnumerator();
    try
    {
      while(en.MoveNext())
      {
        string s = (string)en.Current;
        Console.WriteLine(s);
       }
    }
    finally
    {
      if(en is IDisposable)
        ((IDisposable)en).Dispose();
    }
