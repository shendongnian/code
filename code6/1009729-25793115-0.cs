    using (SchoolEntities context =
        new SchoolEntities())
    {
        // The following three queries demonstrate 
        // three different ways of passing a parameter.
        // The queries return a string result type.
    
        // Use the parameter substitution pattern.
        foreach (string name in context.ExecuteStoreQuery<string>
            ("Select Name from Department where DepartmentID < {0}", 5))
        {
            Console.WriteLine(name);
        }
    
        // Use parameter syntax with object values.
        foreach (string name in context.ExecuteStoreQuery<string>
            ("Select Name from Department where DepartmentID < @p0", 5))
        {
            Console.WriteLine(name);
        }
        // Use an explicit SqlParameter.
        foreach (string name in context.ExecuteStoreQuery<string>
            ("Select Name from Department where DepartmentID < @p0",
                new SqlParameter { ParameterName = "p0", Value = 5 }))
        {
            Console.WriteLine(name);
        }
    }
