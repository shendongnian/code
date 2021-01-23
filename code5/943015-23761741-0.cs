    using System.Text.RegularExpressions;
    ...
    List<JsonTypeFile> AllFiles = new List<JsonTypeFile>();
    foreach(Match match in Regex.Matches(temp, "{[^}]*}"))
    {
      var result = JsonConvert.DeserializeObject<SnSafe.JsonTypeFile>(match.Value);
      AllFiles.Add(result);
    }
    
