    public class Processor
     {
     public ICollection<string> Process(Stream stream)
     {
        StreamReader reader = new StreamReader(stream);
        string pattern = @"set vrouter ""([\w-]+)""";
        Collection<string> myCollection = new Collection<string>(); 
        while (!reader.EndOfStream)
        {
            var matches =
                Regex.Matches(reader.ReadToEnd(), pattern)
                    .Cast<Match>().Where(m => m.Success)
                    .Select(m => m.Groups[1].Value)
                    .Distinct();
    
            foreach (var match in matches)
            {
                var val = match + Environment.NewLine;
          myCollection.Add(val);;  //here error
    
            }
    
        }
    return myCollection;  
    
    }
