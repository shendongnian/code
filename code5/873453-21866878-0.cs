    using Microsoft.Office.Interop.MSProject;
    using System;
    using System.Reflection;
    namespace PProject
    {
        public class Program
        {
             public static void Main()
             {
                 Application projApp = new Application();
                 projApp.FileOpenEx(@"C:\Tickets.mpp", true, Missing.Value, Missing.Value,
                 Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                 Missing.Value, Missing.Value, PjPoolOpen.pjDoNotOpenPool, Missing.Value,
                 Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                 
                 Project proj = projApp.ActiveProject;
                 // Enumerate the tasks
                 foreach (Task task in proj.Tasks)
                 {
                     string name = task.Name;
                     Console.WriteLine(task.Name);
                 }
                 // Make sure to clean up and close the file
                 projApp.FileCloseAll(PjSaveType.pjDoNotSave);
                 }
         }
     }
