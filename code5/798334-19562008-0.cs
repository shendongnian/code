        public class Dog
        {
            public int? Age { get; set; }
            public Guid Id { get; set; }
            public string Name { get; set; }
            public float? Weight { get; set; }
    
            public int IgnoredProperty { get { return 1; } }
        }            
                
        var guid = Guid.NewGuid();
        var dogs = connection.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });
                
        dogs.Count()
            .IsEqualTo(1);
    
        dogs.First().Age
            .IsNull();
    
        dogs.First().Id
           .IsEqualTo(guid);
