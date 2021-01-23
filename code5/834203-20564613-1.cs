    public class TaskConfig() 
    {
        public TaskConfig()
        {
           this.Items = new List<TaskBase>();
        }
        [XmlArray]
        [XmlArrayItem(ElementName="FileTask", Type=typeof(FileTask))]
        [XmlArrayItem(ElementName="DbTask", Type=typeof(DbTask))]
        public List<TaskBase> Items
        {
           get;
           set;
        }
    }
