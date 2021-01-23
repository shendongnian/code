    public class MyDataContextDbInitializer : DropCreateDatabaseIfModelChanges<MyDataContext>
    {
       protected override void Seed(MagazineContext context)
       {
         context.Customers.Add(new Customer() { CustomerName = "Test Customer" });
       }
    } 
