    //[XmlIgnore]   - removed this line and added the next line
    [XmlElement("Tasks")]
    public TaskCollection TaskCollection { get; set; }
    [XmlElement("Task", typeof(UtilitiesTask))]
    public List<UtilitiesTask> TaskList { get; set; }
