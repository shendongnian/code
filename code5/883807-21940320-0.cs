    class Program
    {
        static void Main( string[] args )
        {
            using( var db = new TestEntities() )
            {
                db.EntityBs.Add( new EntityB()
                    {
                        EntityBId = 78
                    } );
                db.SaveChanges();
                Task.WaitAll( Test( db ) );
            }
            var input = Console.ReadLine();
        }
        static Task<List<EntityB>> GetEntityBsAsync( TestEntities db )
        {
            return db.EntityBs.ToListAsync();
        }
        static async Task Test( TestEntities db )
        {
            var a0 = await GetEntityBsAsync( db );
            var a1 = await GetEntityBsAsync( db );
        }
    }
