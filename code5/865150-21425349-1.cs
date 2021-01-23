      string txt="Client_Test_delete.xlsx";
      string re1="(Client)";	// Word 1
      string re2=".*?";	// Non-greedy match on filler
      string re3="_";	// Uninteresting: c
      string re4=".*?";	// Non-greedy match on filler
      string re5="(_)";	// Any Single Character 1
      string re6="(delete)";	// Word 2
      string re7="(\\.)";	// Any Single Character 2
      string re8="(xlsx)";	// Variable Name 1
      Regex r = new Regex(re1+re2+re3+re4+re5+re6+re7+re8,RegexOptions.IgnoreCase|RegexOptions.Singleline);
      Match m = r.Match(txt);
      if (m.Success)
      {
         //Delete file
      }
