     public static void Method(string dir)
        {
            //crash happens here v
            StreamWriter sw = new StreamWriter(@"C:\users\"+Environment.UserName+"\desktop\log.txt",true);
    
            foreach (string subdir in Directory.GetDirectories(dir))
            {
    
                try
                {
    
                    Console.WriteLine(subdir);
                    sw.Write(subdir);
                    //This line you'll call "Method" again
                    Method(subdir);
    
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Error");
                }
            }
          sw.Close(); 
        }
