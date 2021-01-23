    class Manager
    {
        List<Task> _tasks;
    
        public Manager()
        {
            
            _tasks = new List<Task>();
           
            //assuming your 3 tasks are already started from somewhere, run fourth task 
            StartNewTask(Run_NextWork);
        }
    
        public void StartNewTask(Action action)
        {
            //WaitAll waits for all tasks in array to complete before continuing
            Task.WaitAll(_tasks.ToArray());
            var newTask = Task.Run(action);
        }
    
        public void Run_NextWork()
        {
        }
    }
