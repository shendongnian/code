    public class Class1{
        public static void Main(string[] args){
            FileStream stream = null;
            string fullTempPath = null;
            try{
                byte[] page = Resources.HTMLPage1;
                fullTempPath = Path.GetTempPath() + Guid.NewGuid() + ".html";
                stream = new FileStream(fullTempPath, FileMode.Create, FileAccess.Write, FileShare.Read);
                stream.Write(page, 0, page.Length);
                stream.Flush(true);
                stream.Close();
                Process proc = new Process{StartInfo ={FileName = fullTempPath}};
                proc.Start();
            }
            finally{
                if (stream != null){
                    stream.Dispose();
                }
                if (fullTempPath != null){
                    File.Delete(fullTempPath);
                }
            }
        }
    }
