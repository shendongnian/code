    string[] result = test.Split(FirstSeperatorFirstName, StringSplitOptions.RemoveEmptyEntries);
    if(result.Length > 2) {
      string[] inner = result[1].Split(')');
      if(inner.Length > 1) {
        inner[0].Dump();
      }
    }
