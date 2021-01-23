    public Func<WorkItem, Task> WorkAsync { get; set; }
    public async Task WorkAsync(WorkItem item)
    {
          try
          {
                await WorkAsync(item)
          }
          catch (Exception e)
          {
               // Handle
          }
    }
