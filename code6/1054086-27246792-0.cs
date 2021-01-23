    public string MyMethod(string s){
    //Do stuff
      if (string.IsNullOrWhitespace(s)){
        return "failed";
      } else {
        return "passed";
      }
    }
