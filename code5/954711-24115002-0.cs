    public interface IIdentifiableStatus
    {
        int Id { get; }
        string Name { get; }
    }
    public class ContentStatus : IIdentifiableStatus
    {
        public ContentStatus()
        {
            this.Contents = new List<Content>();
        }
        public int ContentStatusId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        int IIdentifiable.Id
        {
            get { return ContentStatusId; }
        }
        string IIdentifiable.Name
        {
            get { return Name; }
        }
    }
    public class TaskStatus : IIdentifiableStatus
    {
        public TaskStatus()
        {
            this.Tasks = new List<Task>();
        }
        public int TaskStatusId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        int IIdentifiable.Id
        {
            get { return TaskStatusId; }
        }
        string IIdentifiable.Name
        {
            get { return Name; }
        }
    }
