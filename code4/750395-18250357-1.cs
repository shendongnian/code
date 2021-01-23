    public class YourInitializer : DropCreateDatabaseIfModelChanges<YourContext>
    {
        protected override void Seed(YourContext context)
        {
            context.Foos.Add(new Foo());
            // ...
            base.Seed(context);
        }
    }
