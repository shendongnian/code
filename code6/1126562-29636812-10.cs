    public class Process
    {
        public string ProcessName { get; set; }
        public string HelpFile { get; set; }
        [XmlElement("Stage")]
        public List<Stage> Stages { get; set; }
        public Process()
        {
            Stages = new List<Stage>();
        }
    }
        
    public class Stage
    {
        [XmlAttribute]
        public string StageName { get; set; }
        [XmlAttribute("StagePage")]
        public string stagepage { get; set; }
        [XmlAttribute("Status")]
        public string StageStatus { get; set; }
        [XmlAttribute("Selected")]
        public bool IsSelected { get; set; }
        [XmlElement("Step")]
        public List<Step> Steps { get; set; }
        public List<User> StageUsers { get; set; }
        public Stage() : this(null) { }
        public Stage(String name)
        {
            StageName = name;
            Steps = new List<Step>();
            StageUsers = new List<User>();
            IsSelected = true;
        }
    }
    public class Step
    {
        [XmlAttribute]
        public string StepName { get; set; }
        [XmlAttribute]
        public string StepPage { get; set; }
        [XmlAttribute("Status")]
        public string StepStatus { get; set; }
        [XmlElement("Task")]
        public List<Task> Tasks { get; set; }
        public List<User> StepUsers { get; set; }
        public Step() : this(null) { }
        public Step(String name)
        {
            StepName = name;
            Tasks = new List<Task>();
            StepUsers = new List<User>();
        }
    }
    public class Task
    {
        [XmlAttribute]
        public string TaskName { get; set; }
        [XmlAttribute]
        public string TaskTip { get; set; }
        [XmlAttribute("Status")]
        public string TaskStatus { get; set; }
        public List<User> TaskUsers { get; set; }
        public Task() : this(null) { }
        public Task(String name)
        {
            TaskName = name;
            TaskUsers = new List<User>();
        }
    }
    public class User
    {
        [XmlAttribute]
        public string Alias { get; set; }
        [XmlAttribute]
        public string FullName { get; set; }
        [XmlAttribute]
        public string Email { get; set; }
        [XmlAttribute]
        public string Role { get; set; }
        [XmlAttribute]
        public string Organization { get; set; }
    }
