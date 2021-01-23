    class Program
    {
        static void Main(string[] args)
        {
            using( var db = new TestEntities() )
            {
                var a0 = new EntityA()
                    {
                        EntityAId = 1,
                        Description = "hi"
                    };
                var a1 = new EntityA()
                    {
                        EntityAId = 2,
                        Description = "bye"
                    };
                db.EntityAs.Add( a0 );
                db.EntityAs.Add( a1 );
                var b = new EntityB()
                {
                    EntityBId = 1,
                    Description = "Big B"
                };
                a1.PrimaryEntityB = b;
                db.SaveChanges();
                // this prints "1"
                Console.WriteLine( b.EntityAsViaPrimary.Count() );
                db.EntityAs.Remove( a1 );
                db.SaveChanges();
                // this prints "0"
                Console.WriteLine( b.EntityAsViaPrimary.Count() );
            }
            var input = Console.ReadLine();
        }
    }
