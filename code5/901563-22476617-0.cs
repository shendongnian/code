    public class Dog
    {
        public int? Age { get; set; }
        ...
    }            
            
    var dogs = connection.Query<Dog>("select Age = @Age", new { Age = 5 });
