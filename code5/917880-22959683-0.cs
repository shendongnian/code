    if (File.Exitst(dir))
    {
      var lines = System.IO.File.ReadLines(dir);
      foreach(string line in lines) {  /* do something */ }
    }
