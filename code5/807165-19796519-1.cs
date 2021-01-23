    Dictionary<string,string> subPatterns = new Dictionary<string,string>();
    subPatterns[@"^(?i)str\.*"] = "Strada";
    subPatterns[@"^(?i)fraz\.*"] = "Frazione";
    subPatterns[@"^(?-i)[^vV]\.*\w{2}\s|\w+\.\w*"] = "";
    //build the compositing pattern from sub patterns
    string pattern = string.Join("|", subPatterns.Select(e=>e.Key));
    //replace it
    StringBuilder address = new StringBuilder();
    int nextStart = 0;
    foreach(Match m in Regex.Matches(sede.Address, pattern)){
      if(m.Success){
         address.Append(sede.Address.Substring(nextStart,m.Index));
         //find the replacement
         foreach(var pat in subPatterns){
           if(Regex.IsMatch(m.Value,pat.Key)){
             address.Append(pat.Value);
             break;
           }
         }
         nextStart = m.Index + m.Length;         
      }
    }
    sede.Address = address.ToString();
