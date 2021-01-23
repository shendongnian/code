     class Program
            {
                static List<Task> taskList = new List<Task>();
                
                static void Main(string[] args)
                {
                    Task.Factory.StartNew(() => { StartTasks("First"); });
                    Task.Factory.StartNew(() => { LoadMethod(); });
                    Task.Factory.StartNew(() => { StartTasks("Second"); StartTasks("Third"); });
                    Task.Factory.StartNew(() => { LoadMethod(); });
                    Task.Factory.StartNew(() => { StartTasks("Four"); });
                    Task.Factory.StartNew(() => { LoadMethod(); });
                    Task.Factory.StartNew(() => { StartTasks("Five"); StartTasks("Six"); StartTasks("Seven"); StartTasks("Eight"); });
                    Task.Factory.StartNew(() => { LoadMethod(); });
                    Task.Factory.StartNew(() => { StartTasks("Nine"); StartTasks("Ten"); });
                    Task.Factory.StartNew(() => { LoadMethod(); });
        
                    Console.WriteLine("Execution is completed !");
                    Console.ReadKey();
                }
        
                public static void LoadMethod()
                {
                    // Lock and wait to not allow any thead to modify the list
                    lock (taskList)
                    {
                        if (taskList.Any())
                        {
                            Task.WaitAll(taskList.ToArray());
                        }
        
                        Debug.WriteLine("*******************Called Another Method***********************");
                        taskList.Clear();
                    }
                }
        
                public static void StartTasks(string taskName)
                {
                    lock (taskList)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            var t = new Task(() =>
                            {
                                Debug.WriteLine(taskName + " @ " + DateTime.Now.ToString());
                                //System.Threading.Thread.Sleep(500);
                            });
                            taskList.Add(t);
                        }
        
                        Task.Factory.StartNew(() => taskList.ForEach(task =>
                        {
                            if (task.Status == TaskStatus.Created)
                            {
                                task.Start();
                            }
                        }), TaskCreationOptions.AttachedToParent);
                    }
                }
            }
