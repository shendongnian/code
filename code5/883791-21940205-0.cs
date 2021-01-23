    static void Main(string[] args)
        {
            // Get the service on the local machine
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Does something";
                // Add a trigger that, starting now, will fire every day
                // and repeat every 1 minute.
                var dt = new DailyTrigger();
                dt.StartBoundary = DateTime.Now;
                dt.Repetition.Interval = TimeSpan.FromSeconds(60);
                td.Triggers.Add(dt);
                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction("notepad.exe", "c:\\test.log", null));
                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition("Test", td);
            }
            Console.ReadLine();
        }
