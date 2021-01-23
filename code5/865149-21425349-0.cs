     string txt="fileName_delete.xlsx";
      string re1=".*?";	// Non-greedy match on filler
      string re2="(_)";	// Any Single Character 1
      string re3="(delete)";	// Word 1
      string re4="(\\.)";	// Any Single Character 2
      string re5="(xlsx)";	// Variable Name 1
      Regex r = new Regex(re1+re2+re3+re4+re5,RegexOptions.IgnoreCase|RegexOptions.Singleline);
      Match m = r.Match(txt);
      if (m.Success)
      {
         //Delete file
      }
