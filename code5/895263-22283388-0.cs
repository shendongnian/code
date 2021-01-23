            List<string> missedFiles = new List<string>();
            if (File.Exists("list.txt"))
            {
                foreach(var line in File.ReadLines("list.txt"))
                {
                   if (File.Exists(line))
                   {
                     Console.WriteLine(files[1]);
                   }
                   else
                   {
                     missedFiles.Add(line);
                   }
                }
                if(miisedFiles.Count>0)
               {
                  foreach(var file in missedFiles)
                  Console.WriteLine(file);
               }
            }
            
            Console.ReadKey(true);
