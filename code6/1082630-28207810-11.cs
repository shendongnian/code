    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace IntervallsTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime exactDate = DateTime.Parse("2015-6-1");
    
                var tc = new TaskCollection();
                tc.Add(new MyTask { name = "T1", startDt = DateTime.Parse("2015-1-1"), endDt = DateTime.Parse("2015-02-01") });
                tc.Add(new MyTask { name = "T2", startDt = DateTime.Parse("2015-1-1"), endDt = DateTime.Parse("2015-07-01") });
                tc.Add(new MyTask { name = "T2a", startDt = DateTime.Parse("2015-1-1"), endDt = DateTime.Parse("2015-07-02") });
                tc.Add(new MyTask { name = "T3", startDt = DateTime.Parse("2015-05-1"), endDt = DateTime.Parse("2015-12-31") });
                tc.Add(new MyTask { name = "T3a", startDt = DateTime.Parse("2015-04-1"), endDt = DateTime.Parse("2015-12-31") });
                tc.Add(new MyTask { name = "T4", startDt = DateTime.Parse("2015-12-1"), endDt = DateTime.Parse("2015-12-31") });
    
                var result = tc.Get(exactDate);
    
                Console.WriteLine("These tasks are active at " + exactDate);
                foreach (var tsk in result)
                {
                    Console.WriteLine(tsk.name);
                }
                Console.WriteLine("press any key");
                Console.ReadKey();
            }
        }
    
        public class TaskCollection
        {
            SortedSet<SameTimeTaskList> startTimeSet = new SortedSet<SameTimeTaskList>(new ByTime());
            SortedSet<SameTimeTaskList> endTimeSet = new SortedSet<SameTimeTaskList>(new ByTime());
    
            static SameTimeTaskList refTime = new SameTimeTaskList();
            static SameTimeTaskList minTime = new SameTimeTaskList { time = DateTime.MinValue };
            static SameTimeTaskList maxTime = new SameTimeTaskList { time = DateTime.MaxValue };
    
            public void Add(MyTask task)
            {
                // startTimeSet
                refTime.time = task.startDt;
                var lst = startTimeSet.GetViewBetween(refTime, refTime).FirstOrDefault();
                if (lst == null) // no bucket found for time
                {
                    lst = new SameTimeTaskList { time = task.startDt };
                    startTimeSet.Add(lst);
                }
                lst.taskList.Add(task); // add task to bucket
                // endTimeSet
                refTime.time = task.endDt;
                lst = endTimeSet.GetViewBetween(refTime, refTime).FirstOrDefault();
                if (lst == null) // no bucket found for time
                {
                    lst = new SameTimeTaskList { time = task.endDt };
                    endTimeSet.Add(lst);
                }
                lst.taskList.Add(task); // add task to bucket
            }
    
            public IEnumerable<MyTask> Get(DateTime exactTime)
            {
                refTime.time = exactTime;
                // set of all tasks started before exactTime
                SortedSet<SameTimeTaskList> sSet = startTimeSet.GetViewBetween(minTime, refTime);
                // set of all tasks ended after exactTime
                SortedSet<SameTimeTaskList> eSet = endTimeSet.GetViewBetween(refTime, maxTime);
    
                List<MyTask> result = new List<MyTask>();
                if (sSet.Count < eSet.Count) // check smaller set for 2nd condition
                {
                    foreach (var tl in sSet)
                        foreach (MyTask tsk in tl.taskList)
                            if(tsk.endDt >= exactTime) result.Add(tsk);
                }
                else // eSet is smaller
                {
                    foreach (var tl in eSet)
                        foreach (MyTask tsk in tl.taskList)
                            if (tsk.startDt <= exactTime) result.Add(tsk);
    
                }
                return result;
            }
        }
    
        public class MyTask
        {
            public string name;
            public DateTime startDt;
            public DateTime endDt;
            // ...
        }
    
        public class SameTimeTaskList
        {
            public DateTime time; // common start or end time of all tasks in list
            public List<MyTask> taskList = new List<MyTask>();
        }
    
        // Defines a comparer to create a sorted set 
        // that is sorted by time. 
        public class ByTime : IComparer<SameTimeTaskList>
        {
            public int Compare(SameTimeTaskList x, SameTimeTaskList y)
            {
                return x.time.CompareTo(y.time);
            }
        }
    }
