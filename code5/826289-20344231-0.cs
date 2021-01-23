           static void Main(string[] args)
            {
                String path = @"C:\datafile.txt";
                String [] allLines= System.IO.File.ReadAllLines(path);
                List<String> newlines=new List<String>();
               
               foreach(String line in  allLines)
               {
                   if (line.Contains("test69.com") || line.Contains("http://test69.com") || line.Contains("man.test"))
                   {
                   }
                   else
                   {
                     newlines.Add(line);                 
                   }
               }    
               System.IO.File.WriteAllLines(path,newlines.ToArray());     
            }
