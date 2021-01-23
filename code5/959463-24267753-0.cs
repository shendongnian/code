    public class Seeder
    {
        public void Seed (DbContext context)
        {
            var myThing = new ReferenceThing
            {
                Id = 1,
                Name = "Thing with Id 1"
            };
    
            context.Set<ReferenceThing>.Add(myThing);
            context.Database.Connection.Open();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT ReferenceThing ON")
            // manually generate SQL & execute
            context.Database.ExecuteSqlCommand("INSERT ReferenceThing (Id, Name) " +
                                               "VALUES (@0, @1)", 
                                               myThing.Id, myThing.Name);
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT ReferenceThing OFF")
        }
    }
