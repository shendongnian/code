    public class CustomRollingFileAppender : RollingFileAppender
        {
            protected override void AdjustFileBeforeAppend()
            {
                var currentFile = File;
                
                FileInfo fa = new System.IO.FileInfo(currentFile);
                if (fa.Length >= 10000000)
                {
                    using (ZipFile zip = new ZipFile(File + ".zip"))
                    {
                        string newFile =  DateTime.Now.ToString("HHmmss") + fa.Name;
                        zip.AddFile(File).FileName = newFile;
                        zip.Save(File + ".zip");
                    }
                }
                base.AdjustFileBeforeAppend();
            }
        }
