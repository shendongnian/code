    var cx = System.IO.File.ReadAllLines(path);
    
    var lineInfo = cx.AsParallel()
        .Select(line => new {
            lineCode = line.Substring(0, 2),
            line
        })
        .ToList()
        .AsParallel();
        
    var employeeDictionary = lineInfo
        .Where(e => e.lineCode == EmployeeLine)
        .Select(e => ParseEmployee(e.line))
        .ToDictionary(e => e.winId);
        
    var dependentLookup = lineInfo
        .Where(e => e.lineCode == DependentLine)
        .Select(e => ParseDependent(e.line))
        .ToLookup(d => d.EmpId);
        
    Parallel.ForEach(employeeDictionary.Values, _options, employee => 
    {
        foreach(var dependent in dependentLookup[employee.winId])
        {
            // It's even better if you can have an "AddDependents" method
            // to avoid the foreach, and leverage the efficiencies of "AddRange"-type
            // methods.
            employee.AddDependent(dependent);
        }
    });
