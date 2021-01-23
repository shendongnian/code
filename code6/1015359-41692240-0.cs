    using System;
    using System.Threading.Tasks;
    
    namespace COREserver{
        public static partial class COREtasks{   // partial to be able to split the same class in multiple files
            public static async void RunHourlyTasks(params Action[] tasks)
            {
                DateTime runHour = DateTime.Now.AddHours(1.0);
                TimeSpan ts = new TimeSpan(runHour.Hour, 0, 0);  // ensure minutes and seconds to be ZERO
                runHour = runHour.Date + ts;
    
    
                while (true)
                {
                    TimeSpan duration = runHour.Subtract(DateTime.Now);
                    if(duration.TotalMilliseconds <= 0.0)
                    { 
                        Parallel.Invoke(tasks);
                        runHour = DateTime.Now.AddHours(1.0);
                        continue;
                    }
                    int delay = (int)(duration.TotalMilliseconds / 2);
                    await Task.Delay(30000);  // 30 seconds
                }
            }
        }
    }
