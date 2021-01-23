    var book = new Book { Name = "Jitterbug Perfume" };
    
    PropertyInfo bokName = typeof(Book)
        .GetProperties(BindingFlags.Public | BindingFlags.Instance) // add other bindings if needed
        .FirstOrDefault(x => x.GetCustomAttribute<ColumnAttribute>() != null
           && x.GetCustomAttribute<ColumnAttribute>().Name.Equals("Bok_Name", StringComparison.OrdinalIgnoreCase));
    
    // the above query only gets the first property with Column attribute equal to "Bok_Name"
    // if there are more than one, then use a .Where clause instead of FirstOrDefault.
    if (bokName != null)
    {
        string name = bokName.GetValue(book).ToString();
        // do other stuff
    }
