     var replacements = new Dictionary<string, string> {
         { "@%a%@","hi" }, { "@%b%@","yo" }, { "@%c%@","asdfasdf" } // ...
     };
     string s = System.IO.File.ReadAllText(path);
     foreach(var repalcement in replacements)
        s = s.Replace(repalcement.Key, repalcement.Value);
      
