    using(var en = SomeStringSource.GetEnumerator())
      while(en.MoveNext())
      {
        string s = (string)en.Current;
        Console.WriteLine(s);
       }
