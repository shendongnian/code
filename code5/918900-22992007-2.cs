        public partial class F2 : Form
        {
            private event EventHandler fileChangedEvent;
            private static string gdalToolsPath = @"Y:\FWTools2.4.7\bin\";
            private static string changeFile = gdalToolsPath + "a.status";
    
            public F2()
            {
                InitializeComponent();
                fileChangedEvent += new EventHandler(F2_fileChangedEvent);
            }
    
            void F2_fileChangedEvent(object sender, EventArgs e)
            {
                // Output changed, read file content
                using (var file = new FileStream(changeFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(file))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // Check file size if it is changed
                new Thread(() =>
                {
                    long len = 0;
                    while (true)
                    {
                        if (File.Exists(changeFile))
                        {
                            FileInfo info = new FileInfo(changeFile);
                            if (info.Length != len)
                            {
                                len = info.Length;
                                fileChangedEvent(this, EventArgs.Empty);
                            }
                        }
    
                        Thread.Sleep(200); // Change poll rate whatever you want
                    }
                }).Start();
    
                new Thread(() =>
                {
                    using (Process process = new Process())
                    {
                        ProcessStartInfo info = new ProcessStartInfo();
                        info.FileName = "cmd.exe";
                        info.Arguments = "/C \"" + gdalToolsPath + "gdalwarp.exe -of GTiff -co \"INTERLEAVE=PIXEL\" -s_srs \"+proj=utm +zone=31 +datum=WGS84\" -t_srs \"+proj=latlong +datum=WGS84\" -r cubic aa.tif bb.tif\" >a.status";
                        info.UseShellExecute = false;
                        info.CreateNoWindow = true;
                        info.WorkingDirectory = gdalToolsPath;
    
                        process.StartInfo = info;
                        process.Start();
                        process.WaitForExit();
    
                        File.Delete(changeFile);
                    }
                }).Start();
            }
        }    
