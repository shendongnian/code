    public class NameOption
    {
         public string Name { get; set; }
         public int Weight { get; set; }
    
         public NameOption(string name, int weight)
         {
             Name = name;
             Weight = weight;
         }
    }
    // Will need the System.Linq namespace declared in order to use the LINQ statements
    public string PickName()
    {
        var nameOptions = new List<NameOption> 
                    {
                        new NameOption("Bob",5),
                        new NameOption("John", 1),
                        etc...
                    };
        // FYI - following won't work if Weight was a negative value or 0.
        var namesToPickFrom = new string[nameOptions.Sum(x => x.Weight)];
        var nameIndex = 0;
        foreach (var option in nameOptions)
        {
           for (var i = 0; i < option.Weight; i++)
               namesToPickFrom[nameIndex++] = option.Name;
        }
        var random = new Random();
        return namesToPickFrom[random.Next(0, namesToPickFrom.Length-1)];
    }
