    public Task
    {
       public string Description { get; set; }
       // what do I put here?
       public Person CompletedByPerson { get; set; }
    }
    public Person
    {
       public string FullName { get; set; }
       // what do I put here?
       public List<Task> CompletedTasks { get; set; }
    }
