    class Program
    {
        static void Main(string[] args)
        {
    
            List<File> FileList = new List<File>();
            FileList.Add(new File { FullPath = "File1" });
            FileList.Add(new File { FullPath = "File2" });
            FileList.Add(new File { FullPath = "File3" });
            FileList.Add(new File { FullPath = "File4" });
            FileList.Add(new File { FullPath = "File5" });
            //FileList.Add(new FileName { FullPath = "File5" });
    
            foreach (File SourceFile in FileList) 
            {
                foreach (File TestFile in FileList) 
                {
                    if (SourceFile.GetName() == TestFile.GetName() && !(Object.ReferenceEquals(SourceFile, TestFile)))
                    {
                        var lbl_message = "There where duplicates files found please check the files and try again";
                    }
                    else 
                    {
                        //another stuff
                    }
                }                    
            }
        }
    }
    
    public class File
    {
        public string FullPath;
    
        public string GetName()
        {
            return FullPath;
        }
    }
