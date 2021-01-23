    public class ParentTask
    {
        int TaskId { get; set; }
        int ParentTaskId { get; set; }
        String TaskName { get; set; }
        String DueDate { get; set; }
        String CompletionDate { get; set; }
        String Description { get; set; }
        String AssignedTo { get; set; }
        String Tags { get; set; }
        public List<object> Attr;
        public ParentTask(int taskId, int parentTaskId, String taskName, String dueDate, String completionDate, String description, String assignedTo, String tags)//constructor
        {
            TaskId = taskId;
            ParentTaskId = parentTaskId;
            TaskName = taskName;
            DueDate = dueDate;
            CompletionDate = completionDate;
            Description = description;
            AssignedTo = assignedTo;
            Tags = tags;
            Attr = new List<object>();
            Attr.Add(TaskId);
            Attr.Add(ParentTaskId);
            Attr.Add(TaskName);
            Attr.Add(DueDate);
            Attr.Add(CompletionDate);
            Attr.Add(Description);
            Attr.Add(AssignedTo);
            Attr.Add(Tags);
        }
    }
