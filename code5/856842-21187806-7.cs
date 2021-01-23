     try this     
     typeof(TestContext).GetProperties().Select(n => n.PropertyType) // here we get all properties of contect class
    .Where(n => n.Name.Contais("DbSet") && n.IsGenericType) // here we select only DBSet collections
    .Select(n=>n.GetGenericArgumenrs()[0])//Here we access to TEntiy type in DbSet<TEntity> 
    .Where(n => n.GetCustomAttributes(true).OfType<DoNotAudit>().FirstOrDefault()== null) // here we check for attribute existence
     .OrderBy(n=>n.Name) // Here is sorting by Name
    .Select(n => n.Name).ToList(); // here we select the names of entity classes
