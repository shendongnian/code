    ...
    Dictionary<int, bool> processed = new Dictionary<int, bool>();
    Queue<Employee> managersQueue = new Queue<Employee>();
    managersQueue.Enqueue(employee);
    while (managersQueue.Any())
    {
        var currentEmployee = stack.Dequeue();
        var managers = employeeList.Where(x => currentEmployee.DirectManagers.Any(y => y.Equals(x.Id)));
        foreach (var manager in managers)
        {
            if (processed.ContainsKey(manager.Id)) continue;
            processed.Add(manager.Id, true);
            managersQueue.Enqueue(manager);
        }
    }
    return processed.ToList();
