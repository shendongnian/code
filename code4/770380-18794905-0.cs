    public class Scheduler {
        private readonly List<Task> _Tasks;
        private Timer _Timer;
        public Scheduler() {
            _Tasks = new List<Task>();
        }
        public void ScheduleTask(Task task) {
            _Tasks.Add(task);
        }
        public void CancelTask(Task task) {
            _Tasks.Remove(task);
        }
        //Start the timer.
        public void Start() {
            //Set the interval based on what amount of accurcy you need.
            _Timer = new Timer {
                Interval = 1000
            };
            _Timer.Elapsed += (sender, args) => UpdateTasks();
            _Timer.Enabled = true;
        }
       //Check to see if any task need to be executed.
        private void UpdateTasks() {
            for (int i = 0; i < _Tasks.Count; i++) {
                Task task = _Tasks[i];
                if (task.ExecuteTime >= DateTime.Now) {
                    task.Callback();
                    _Tasks.Remove(task);
                }
                _Tasks.Remove(task);
            }
        }
        //Stop the timer when you are done.
        public void Stop() {
            _Timer.Dispose();
        }
    }
    //Use this to schedule a task.
    public class Task {
        public DateTime ExecuteTime { get; set; }
        public Action Callback { get; set; }
        public Task(DateTime executeTime, Action callback) {
            ExecuteTime = executeTime;
            Callback = callback;
        }
    }
