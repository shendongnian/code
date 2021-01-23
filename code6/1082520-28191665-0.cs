    handler for directory created
     {
             string YourFolder = @"D:\CPT\Folder\"; // just en example
             DirectoryInfo di1 = new DirectoryInfo(YourFolder);
             DateTime dt1 = di1.LastWriteTime; // that is your base folder write time
             Console.WriteLine(dt1);
             Stopwatch sw = new Stopwatch(); //it's from System.Diagnostics
             sw.Restart();
             int secondWithoutAccess = 0;
             do
             {
               if (sw.ElapsedMilliseconds > 1000)
               {
               //You must create new instance of Directory info every second
               DirectoryInfo di2 = new DirectoryInfo(YourFolder);
               DateTime dt2 = di2.LastWriteTime;
               Console.WriteLine(dt2);
               //if your base lastWriteTime is lower than 
                   if (dt2 > dt1)
                   {
                       secondWithoutAccess = 0;
                       dt1 = dt2; // You must write last write time to proper compare
                   }
                   else secondWithoutAccess++;
               sw.Restart(); // in all cases You restart timer
               }
             }
             while (secondWithoutAccess < 30);  // when 30 sec without access
             Console.WriteLine("Files in folder didn't change for more than 30 sec");
            // do rest of Your stuff here
        }
