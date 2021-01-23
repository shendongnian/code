     public class TaskConfiguration 
        {
            public string Task_Name
            {
                get;
                set;
            }
    
            public string task_id
            {
                get;
                set;
            }
        }
    public class TaskManagingProcess
    {
        private TaskConfiguration taskConfiguration;
    
        public TaskManagingProcess(TaskConfiguration taskConfiguration)
        {
            this.taskConfiguration = taskConfiguration;
        }
    
        public void InsertTaskProperties(string taskId, string name)
        {
            taskConfiguration.task_id = taskId;
            taskConfiguration.Task_Name = name;         
        }
    }
