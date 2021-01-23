    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EmailAddress
    {
        public int Id { get; set; }
        public Email Email { get; set; }
    }
    public class Email
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    
    public static void Main()
    {
        var people = new []
        {
            new Person() { Id = 1, Name = "John" },
            new Person() { Id = 2, Name = "Paul" },
            new Person() { Id = 3, Name = "George" },
            new Person() { Id = 4, Name = "Ringo" }
        };
        var addresses = new[]
        {
            new EmailAddress() { Id = 2, Email = new Email() { Name = "Paul", Address = "Paul@beatles.com" } },
            new EmailAddress() { Id = 3, Email = new Email() { Name = "George", Address = "George@beatles.com" } },
            new EmailAddress() { Id = 4, Email = new Email() { Name = "Ringo", Address = "Ringo@beatles.com" } }
        };
        
        var joinedById = people.LeftJoin(addresses, p => p.Id, a => a.Id, (p, a) => new
        {
            p.Id,
            p.Name,
            a?.Email.Address
        }).ToList();
        
        Console.WriteLine("\r\nJoined by Id:\r\n");
        joinedById.ForEach(j => Console.WriteLine($"{j.Id}-{j.Name}: {j.Address ?? "<null>"}"));
        var joinedByName = people.LeftJoin(addresses, p => p.Name, a => a?.Email.Name, (p, a) => new
        {
            p.Id,
            p.Name,
            a?.Email.Address
        }, StringComparer.OrdinalIgnoreCase).ToList();
        Console.WriteLine("\r\nJoined by Name:\r\n");
        joinedByName.ForEach(j => Console.WriteLine($"{j.Id}-{j.Name}: {j.Address ?? "<null>"}"));
    }
