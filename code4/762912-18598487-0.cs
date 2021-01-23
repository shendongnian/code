    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    static void Main(string[] args)
    {
        var file = "B.txt";
        var list = new List<Person>();
        
        ReadFile(file, list);
        
        list[1].LastName = "newValue";
    }
    
    private static void ReadFile(string file, List<Person> personList)
    {
        var items = File.ReadLines(file)
                        // Take each value and tag it with its index
                        .Select((s, i) => new { Value = s, Index = i })
                        // Put the values into groups of 2
                        .GroupBy(item => item.Index / 2, item => item.Value)
                        // Take those groups and make a person
                        .Select(g => new Person { FirstName =  g.FirstOrDefault(), LastName = g.Skip(1).FirstOrDefault() });
        
        personList.AddRange(items);
    }
