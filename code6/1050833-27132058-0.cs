    class Program
    {
    
        static void Main(string[] args)
        {
    
           string originalinput = Console.ReadLine();
           string userinput = originalinput.ToLower();
    
           if (!userinput.StartsWith("filter") || !userinput.StartsWith("exit") || !userinput.StartsWith ("stop"))
           {
               DirectoryInfo folderInfo = new DirectoryInfo("C:\\Users\\Connor\\Desktop");
               FileInfo[] files = folderInfo.GetFiles();
               Console.WriteLine("There Are " + folderInfo.GetFiles().Length + "Which Meet The Requirement of The Search");
    
               for (int index = 0; index < files.Length; index++)
               {
                   Console.WriteLine(" " + files[index].Name + " - " + files[index].Length + " - " + files[index].LastWriteTime);
    
               }
               Console.ReadLine();
           }
           else if(userinput == "filter")
           {
    
           }
        }
    }
