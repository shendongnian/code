    public class MyService()
    {
        public IEnumerable<string> LoadTasks()
        {
            var taskList = new List<string>();
            try
            {
                StreamReader task = new StreamReader(dataFolder + TasksFile);
                string tasks = task.ReadLine();
                while (tasks != null)
                {
                    taskList.Add(tasks);
                    tasks = task.ReadLine();
                }    
            }
            catch
            {
            }
            return taskList;
        }
    }
    public Form MainForm()
    {
        private MyService _myService = new MyService();
        public static void TaskPopulate()
        {
            foreach(var task in _myService.LoadTasks())
            {
                cbTask.Items.Add(task);
            }
        }
    }
