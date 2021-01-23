    class TestEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
    static void Main()
    {
        var testCollection = new TestEntity[]{
            new TestEntity(){
                Id = 0,
                FirstName = "abc",
                LastName = "def",
                CompanyName = "ghi"
            },
            new TestEntity(){
                Id = 1,
                FirstName = "def",
                LastName = "ghi",
                CompanyName = "jkl"
            },
            new TestEntity(){
                Id = 2,
                FirstName = "ghi",
                LastName = "jkl",
                CompanyName = "mno"
            },
            new TestEntity(){
                Id = 3,
                FirstName = "bcd",
                LastName = "efg",
                CompanyName = "hij"
            },
        };
        var keywords = new[]{
                "abc",
                "jkl"
            };
        var query = testCollection.AsQueryable()
            .TestPerKey( 
                keywords,
                ( t, k ) => 
                    t.FirstName.Contains( k ) || 
                    t.LastName.Contains( k ) || 
                    t.CompanyName.Contains( k ) );
        foreach( var result in query )
        {
            Console.WriteLine( result.Id );
        }
    }
