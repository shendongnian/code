    public class TaskItem
    {
        public string Name { get; set; }
        public string Instruction { get; set; }
        public bool IsTlc { get; set; }
    }
    [XmlRoot("TaskList")]
    public class TaskList
    {
        public string Name { get; set; }
        public string Revision { get; set; }
        public bool Optional { get; set; }
        [XmlArray("TaskItems")]
        [XmlArrayItem("TaskItem")]
        public List<TaskItem> TaskItems { get; set; }
    }
