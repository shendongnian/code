     try this     
     typeof(TestContext).GetProperties().Select(n => n.PropertyType) // here we get all properties of contect class
    .Where(n => n.Name.Contais("DbSet") && n.IsGenericType) // here we select only DBSet collections
    .Select(n=>n.GetGenericArgumenrs()[0])
    .Where(n => n.GetCustomAttributes(true).OfType<DoNotAudit>().FirstOrDefault()== null) // here we check for attribute existence
    .Select(n => n.Name).ToList(); // here we select the names of entity classes
