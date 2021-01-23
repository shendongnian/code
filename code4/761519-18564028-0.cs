    foreach (Employee e in personList.OfType<Employee>())
    {
        Debug.WriteLine(e.salary.toString());
    }
    foreach (Guest g in personList.OfType<Guest>())
    {
        Debug.WriteLine(g.id.toString());
    }
