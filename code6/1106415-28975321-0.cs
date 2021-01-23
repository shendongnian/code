    public void Main()
    {
        DoAllWorks().Wait();
        // rest of code, which is called
        OtherMethods();
    }
    
    public async Task DoAllWorks()
    {
        ICollection<int> workToDo = GetSomeWorkFromSomewhere();
        IEnumerable<Task<int>> tasks = workToDo.Select(i=> DoWorkAsync(i));
        int[] results = await Task.WhenAll(tasks);
        Debug.Write(results.Sum());
    }
    
