    public class YourInitializer : DropCreateDatabaseIfModelChanges<YourContext>
    {
        protected override void Seed(YourContext context)
        {
            context.Foos.Add(new Foo());
            // ...
            context.SaveChanges();
            base.Seed(context);
        }
    }
