    public class Task
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TaskId { get; private set; }
    public string Name { get; set; }
    public int? ParentTaskId { get; private set; }
    
    [ForeignKey("ParentTaskId")]
    public Task ParentTask { get; set; }
    
    public List<Task> SubTasks { get; set; }
    
    public Task()
    {
    SubTasks = new List<Task>();
    }
    }
