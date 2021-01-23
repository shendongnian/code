    [Serializable]
    [XmlRoot("tasks")]
    public class TasksConfig
    {
        [XmlElement(typeof(DbTask)), XmlElement(typeof(FileTask))]
        public List<TaskBase> list = new List<TaskBase>();
        public void Add(TaskBase item){
            list.Add(item);
        }
    }
