    using (var session = documentstore.OpenSession())
    {
        var test = new List<string>();
        test.Add("emps/81993");
        test.Add("emps/40319");
        Employee[] employees = session.Load<Employee>(test);
        foreach (var employee in employees)
        {
            session.Delete(employee);
        }
                
        session.SaveChanges();
    }
