    public class DatabaseInitializer : DropCreateDatabaseAlways<NameOfContext>
	{
		protected override void Seed(NameOfContext context)
		{
			SeedTestData(context);
			base.Seed(context);
		}
        private static void SeedTestData(NameOfContext context)
		{
            var item = new Item
            {
                Id = 1
            }
            context.DatabaseObjectBeingAddedTo.Add(item);
        }
    }
