    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var pTasks = Task.GetTasks();
                var s1 = Stopwatch.StartNew();
                var count1 = pTasks.Count(x => x.StatusID == (int)BusinessRule.TaskStatus.Pending);
                s1.Stop();
                count1 = (int)s1.ElapsedTicks;
                var s2 = Stopwatch.StartNew();
                var count2 = 
                    (
                        from A in pTasks
                        where A.StatusID == (int)BusinessRule.TaskStatus.Pending
                        select A
                        ).ToList().Count();
                s2.Stop();
                count2 = (int)s2.ElapsedTicks;
                var s3 = Stopwatch.StartNew();
                var count3 = pTasks.Where(x => x.StatusID == (int)BusinessRule.TaskStatus.Pending).Count();
                s3.Stop();
                count3 = (int)s3.ElapsedTicks;
                var s4 = Stopwatch.StartNew();
                var count4 =
                    (
                        from A in pTasks
                        where A.StatusID == (int)BusinessRule.TaskStatus.Pending
                        select A
                        ).Count();
                s4.Stop();
                count4 = (int)s4.ElapsedTicks;
            }
        }
        public class Task
        {
            public static IEnumerable<Task> GetTasks()
            {
                for (int i = 0; i < 1000000; i++)
                {
                    yield return new Task { StatusID = i % 3 };
                }
            }
            public int StatusID { get; set; }
        }
        public class BusinessRule
        {
            public enum TaskStatus
            {
                Pending,
                Other
            }
        }
    }
