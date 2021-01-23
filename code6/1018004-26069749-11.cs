    List<MyEmployee> original = ...
    // you take your list
    // and you split it in sections of .. say 50 (which in my book is not huge for a database
    // although be careful - the pressure on the database will be almost that of 50 selects running in parallel for each select)
    
    // how do you split it?
    // you could try this
    public static IEnumerable<List<MyEmployee>> Split(List<MyEmployee> source, int sectionLength) {
        List<MyEmployee> buffer = new List<MyEmployee>();
        foreach (var employee in source) {
            buffer.Add(employee);
            if (buffer.Count == sectionLength) {
                yield return buffer.ToList(); // MAKE SURE YOU .ToList() the buffer in order to clone it
                buffer.Clear(); // or otherwise all resulting sections will actually point to the same instance which gets cleared and refilled over and over again
            }             
        }
        if (buffer.Count > 0)   // and if you have a remainder you need that too
           yield return buffer; // except for the last time when you don't really need to clone it
    }
    List<List<MyEmployee>> sections = Split(original, 50).ToList();
    // and now you can use the sections
    // as if you're in CASE 2 (the list is not huge but the table is)
    // inside a foreach loop
    List<Person> results = new List<Person>(); // prepare to accumulate results
    foreach (var section in sections) {
        int[] ids = (from x in section select x.EntityID).ToArray();
        var query = from employee in _context.Employee
                    where ids.Contains(employee.EmployeeId) 
                    ... etc;
        var currentBatch = query.ToArray();
        results.AddRange(currentBatch);
    }
