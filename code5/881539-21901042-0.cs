    public class Processor
        {
    
            public IList<string> Process(Stream
                 stream)
            {
                StreamReader reader = new StreamReader(stream);
                string pattern = @"set vrouter ""([\w-]+)""";
                List<string> myCollection = new List<string>();
    
                    var matches =
                        Regex.Matches(reader.ReadToEnd(), pattern)
                            .Cast<Match>().Where(m => m.Success)
                            .Select(m => m.Groups[1].Value)
                            .Distinct();
    
    
                        foreach (var match in matches)
                        {
                        myCollection.Add(match);
                        }
    
    
                return myCollection;
     
    
            }
        }
