    you can try this code....i  think it will help you.
    
    public class FileSearch
        {
            public static Boolean SearchFiles(string path1, string path2)
            {
                bool isIdentical = false;
                string content1 = null;
                string content2 = null;
    bool result=false;
    
                DirectoryInfo d1 = new DirectoryInfo(path1);
                DirectoryInfo d2 = new DirectoryInfo(path2);
    
                foreach (FileInfo f1 in d1.GetFiles("*.txt", SearchOption.AllDirectories))
                {
                    foreach (FileInfo f2 in d2.GetFiles("*.txt", SearchOption.AllDirectories))
                    {
                        content1 = (File.ReadAllText(f1.DirectoryName + "\\" + f1));
                        content2 = (File.ReadAllText(f2.DirectoryName + "\\" + f2));
    
                        isIdentical = content1.Equals(content2, StringComparison.Ordinal);
    
                        if (isIdentical == false)
                        {
                           break;
                        }
                        else
                        {
                            result=true;break;
    
                        }
    break;
                }
    return result;
            }
    
        }
