    public class TaskController : Controller
    {
        String[] values = new fileReader().values;
        public List<ParentTask> TaskList = new List<ParentTask>();
        public ViewResult Index()
        {
            // These were not used
            //string tId = values[0];
            //string tPId = values[1];
            //string tName = values[2];
            //string tD = values[3];
            //string tC = values[4];
            //string tDe = values[5];
            //string tA = values[6];
            //string tT = values[7];
            // The constructor may not be called on each page load, so clear the list
            TaskList.Clear();
            for (int i = 8; i < values.Length; i += 8)
            {
                TaskList.Add(new ParentTask(Convert.ToInt32(values[i]), Convert.ToInt32(values[i + 1]), values[i + 2], values[i + 3], values[i + 4], values[i + 5], values[i + 6], values[i + 7]));
            }
            // Return a strongly typed view with our list of tasks as the ViewModel
            return View(TaskList);
        }
