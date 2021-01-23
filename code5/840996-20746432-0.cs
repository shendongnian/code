    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        static void Main(string[] args)
        {
            var actvProject = new Project();
    
            var taskInfoDic = actvProject.Tasks.Cast<Task>().Select(
            task => new
            {
                task.Guid,
                task.Name
            }).ToDictionary(x => x.Guid);
    
            actvProject.Tasks[0].Name = "New Task";
    
            foreach (var t in taskInfoDic)
            {
                Console.WriteLine(t.Value.Name);    // Still "Task 1"
            }
            // This won't compile as "Name" is readonly.
            // taskInfoDic.ElementAt(0).Value.Name = "test";
        }
    }
    
    public class Project
    {
        public Project()
        {
            Tasks = new List<Task> { new Task { Name = "Task 1" } };
        }
    
        public IList<Task> Tasks { get; set; }
    }
    
    public class Task
    {
        public Guid Guid { get; set; }
    
        public string Name { get; set; }
    }
