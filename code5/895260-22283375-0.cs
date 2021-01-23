            if (File.Exists("list.txt"))
            {
                bool missingFiles = false;
                string[] files = File.ReadAllLines("list.txt");
                foreach(string file in files)
                {
                   if(!File.Exists(file))
                   {
                      missingFiles = true;
                      break;
                   }
                }
                if(missingFiles == true)
                    Console.WriteLine("Cannot find som' files");
            }
            else
            {
                Console.WriteLine("Cannot find list file");
            }
