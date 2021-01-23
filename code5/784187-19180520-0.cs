    // Sample for the Environment.GetFolderPath method 
    using System;
    
    class Sample 
    {
        public static void Main() 
        {
           var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
           Console.WriteLine(folder);
           Console.ReadLine();
        }
    }
