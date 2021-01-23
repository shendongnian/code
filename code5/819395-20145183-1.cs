    static void Main(string[] args)
    {
        var list = new List<Expression<Func<Entity, object>>>();
        list.Add(e => e.Date);
        list.Add(e => e.Name);
        using (var c = new EntityContext())
        {
            //each time a new record is added
            var data = new Entity
            {
                Name = string.Format("Data{0}", c.Entities.Count()),
                Date = DateTime.Now
            };
            c.Entities.Add(data);
            c.SaveChanges();
            // sort by date
            foreach (var e in c.Entities.OrderBy(list.First().Compile()))
                Console.WriteLine(string.Format("{0} - {1}", e.Name, e.Date));
            // sort by name .. in reverse
            foreach (var e in c.Entities.OrderByDescending(list.Last().Compile()))
                Console.WriteLine(string.Format("{0} - {1}", e.Name, e.Date));
        }
        Console.ReadLine();
    }
