    public class CustomerEntity : TableEntity { public string Email { get; set; } } 
    ...
    var storageAccount = CloudStorageAccount.Parse( "MyStorageAccountConnectionstring");
    var tableClient = storageAccount.CreateCloudTableClient();
    var table = tableClient.GetTableReference("myTable");
    // Linq Query with Where And First
    var person = table.CreateQuery<CustomerEntity>()
        .Where(c => c.Email == "Walter1@contoso.com").First();
    // Linq query that used the First() Extension method
    person = table.CreateQuery<CustomerEntity>()
        .First(c => c.Email == "Walter1@contoso.com");
