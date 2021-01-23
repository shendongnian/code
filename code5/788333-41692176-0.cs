    using System;
    using System.Threading.Tasks;
    
    namespace COREserver{
        public static partial class COREtasks{   // partial to be able to split the same class in multiple files
            public static async void RunHourlyTasks(params Action[] tasks)
            {
                DateTime runHour = DateTime.Now.AddHours(1.0);
                TimeSpan ts = new TimeSpan(runHour.Hour, 0, 0);
                runHour = runHour.Date + ts;
    
    
                Console.WriteLine("next run will be at: {0} and current hour is: {1}", runHour, DateTime.Now);
                while (true)
                {
                    TimeSpan duration = runHour.Subtract(DateTime.Now);
                    if(duration.TotalMilliseconds <= 0.0)
                    { 
                        Parallel.Invoke(tasks);
                        Console.WriteLine("It is the run time as shown before to be: {0} confirmed with system time, that is: {1}", runHour, DateTime.Now);
                        runHour = DateTime.Now.AddHours(1.0);
                        Console.WriteLine("next run will be at: {0} and current hour is: {1}", runHour, DateTime.Now);
                        continue;
                    }
                    int delay = (int)(duration.TotalMilliseconds / 2);
                    await Task.Delay(30000);  // 30 seconds
                }
            }
        }
    }
