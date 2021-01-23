    using System.Text.RegularExpressions;
    ...
      Regex rx = new Regex(@"[^\-]\-(.*)");
      string s = "A1234-111";
      Match m = rx.Match(s);
      System.Diagnostics.Debug.WriteLine("Match is " + m.Groups[1].Value);
    ...
