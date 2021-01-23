    private static void Main(string[] args)
    {
      string[] strArray1 = new string[4]
      {
        "d",
        "c",
        "a",
        "b"
      };
      string[] strArray2 = strArray1;
      if (Program.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate2 == null)
      {
        // ISSUE: method pointer
        Program.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate2 = new Func<string, string>((object) null, __methodptr(\u003CMain\u003Eb__0));
      }
      Func<string, string> keySelector1 = Program.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate2;
      foreach (string str in (IEnumerable<string>) Enumerable.OrderBy<string, string>((IEnumerable<string>) strArray2, keySelector1))
        Console.WriteLine(str);
      string[] strArray3 = strArray1;
      if (Program.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate3 == null)
      {
        // ISSUE: method pointer
        Program.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate3 = new Func<string, string>((object) null, __methodptr(\u003CMain\u003Eb__1));
      }
      Func<string, string> keySelector2 = Program.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate3;
      foreach (string str in (IEnumerable<string>) Enumerable.OrderBy<string, string>((IEnumerable<string>) strArray3, keySelector2))
        Console.WriteLine(str);
    }
    [CompilerGenerated]
    private static string \u003CMain\u003Eb__0(string letter)
    {
      return letter;
    }
    [CompilerGenerated]
    private static string \u003CMain\u003Eb__1(string letter)
    {
      return letter;
    }
