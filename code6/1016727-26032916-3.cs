    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace CustomTaskPoolManager
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Define well-known objects and tasks.
                CustomObject[] objects = {
                    new CustomObject("A"),
                    new CustomObject("B"),
                    new CustomObject("C")
                };
                CustomTask[] tasks = {
                    new CustomTask("1"),
                    new CustomTask("2"),
                    new CustomTask("3"),
                    new CustomTask("4"),
                    new CustomTask("5")
                };
                // Define work to be performed (task x object).
                WorkItem[] workItems = CreateInterestingWork(objects, tasks);
                Console.WriteLine("Work items to process: {0}.", workItems.Length);
            
                // Work groups combine work items which
                // need to be processed sequentially
                // (those where the object and the task are the same).
                // I am fully materialising the grouped collection
                // via .ToArray() as I am unsure as to the thread
                // safety of the IEnumerable<IGrouping<T>> implementation
                // (which is beyond the scope of the quesion).
                WorkItem[][] workItemGroups = workItems
                    .GroupBy(i => new { i.Object, i.Task }, (key, group) => group.ToArray())
                    .ToArray();
                var sw = Stopwatch.StartNew();
                // Note that I am not limiting the degree of parallelism here.
                // Since all work is CPU-bound, Parallel.ForEach will
                // determine the best value on its own.
                Parallel.ForEach(workItemGroups, workItemGroup =>
                {
                    // WorkItems with the same Object and
                    // Task are processed sequentially.
                    foreach (WorkItem workItem in workItemGroup)
                    {
                        workItem.Execute();
                    }
                });
                Console.WriteLine("Done. Time elapsed: {0:0.000} s.", (double)sw.ElapsedMilliseconds / 1000);
                Console.ReadLine();
            }
            private static WorkItem[] CreateInterestingWork(CustomObject[] objects, CustomTask[] tasks)
            {
                var workItems = new List<WorkItem>();
                foreach (var o in objects)
                {
                    foreach (var t in tasks)
                    {
                        // Let's add a few idential items here -
                        // those that can't be processed in parallel.
                        workItems.Add(new WorkItem(o, t));
                        workItems.Add(new WorkItem(o, t));
                        workItems.Add(new WorkItem(o, t));
                    }
                }
                // Repeat work items to create duplicate object-task combinations.
                workItems = workItems
                    .Concat(workItems)
                    .Concat(workItems)
                    .ToList();
                return workItems.ToArray();
            }
            class CustomObject
            {
                public string Name { get; private set; }
                public CustomObject(string name)
                {
                    this.Name = name;
                }
                public override string ToString()
                {
                    return "Object " + this.Name;
                }
            }
            class CustomTask
            {
                public string Name { get; private set; }
                public CustomTask(string name)
                {
                    this.Name = name;
                }
                public override string ToString()
                {
                    return "Task " + this.Name;
                }
            }
            class WorkItem
            {
                public CustomObject Object { get; private set; }
                public CustomTask Task { get; private set; }
                public WorkItem(CustomObject o, CustomTask t)
                {
                    this.Object = o;
                    this.Task = t;
                }
                public void Execute()
                {
                    Console.WriteLine("Task {0} started on object {1}.", this.Task.Name, this.Object.Name);
                    Thread.Sleep(100);
                    Console.WriteLine("Task {0} finished on object {1}.", this.Task.Name, this.Object.Name);
                }
            }
        }
    }
