    IEnumerator<int> e = ((IEnumerable<int>)values).GetEnumerator();//Get the enumerator
    try
    {
      int m;//This variable is here prior to c#5.0
      while(e.MoveNext())
      {//int m; is declared here starting from c#5.0
        m = (int)(int)e.Current;
        //Your code here
      }
    }
    finally
    {
      if (e != null) ((IDisposable)e).Dispose();
    }
