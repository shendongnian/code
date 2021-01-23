     static void MultipleExpressionInSelectStatement()
        {
            List<person> p = new List<person>();
            p.Add(new person() { name = "AB", age = 18 });
            p.Add(new person() { name = "CD", age = 45 });
            var dto = p.Select(d => new person()
            {
                name=d.name,
                age=p.Select(ListExtensions.CustomExpression()).ElementAt(0)
            });
        }
    //customExpression
     public static class ListExtensions
    {
      
        public static Func<person, int> CustomExpression()
        {
            return x => x.age;
        }
    }
    //Person Object
     public class person
    {
        public string name { get; set; }
        public int age { get; set; }
    }
