    public class Person
    {
       public string Name { get; set; }
       public uint Age { get; set; }
    }
    private void TestMethod()
    {
        //--peoples collection
        var persons = new[]
        {
            new Person {Age = 10, Name = "Ten"},
            new Person {Age = 20, Name = "Twenty"},
            new Person {Age = 30, Name = "Thirty"},
            new Person {Age = 40, Name = "Forty"},
            new Person {Age = 50, Name = "Fifty"}
        };
        //--test query
        const string column = "Age";
        const int value = 20;
        //--build the expression & compile
        var expression = EqualComparer<Person>(column, value).Compile();
        //--run the query
        var selected =
            from p in persons
            where p.Name.Length > 0 && expression(p)
            select p;
        //--iterate through results
        foreach (var person in selected)
        {
            Debug.WriteLine(person.Name);
        }
    }
