       public static void filesInfoInDir(string dirPath)
        {
            
            try
            {
                foreach (string f in Directory.GetFiles(dirPath))
                {
                    
                    FileInfo file = new FileInfo(Path.Combine(dirPath,f));
                    long s1 = file.Length;
          //This will write the file names along with their size separated with a comma
                    Console.WriteLine(f + "," + s1);
                    
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            
        }
