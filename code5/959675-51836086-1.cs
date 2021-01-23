    namespace WindowsFormsApplication1
    {
        public partial class FormFtpLibraryExtensionDemo : Form
        {
            public FormFtpLibraryExtensionDemo()
            {
                InitializeComponent();
            }
            public static FTP ftplib = null;
            public void ProgressEvent(System.IO.FileInfo File, long BytesTotal, long FileSize, long TotalBytesDirectorySent, long TotalBytesDirectory, long StartTickCount)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new MethodInvoker(delegate() { ProgressEvent(File, BytesTotal, FileSize, TotalBytesDirectorySent, TotalBytesDirectory, StartTickCount); }));
                    return;
                }
    
                TimeSpan elapsedSpan = new TimeSpan(DateTime.Now.Ticks - StartTickCount);
    
                labelFilename.Text = "Filename: " + File.FullName;
                labelCurrentSend.Text = "Current: " + (BytesTotal / 1024).ToString() + "/" + (FileSize / 1024).ToString() + " KB";
                labelTotal.Text = "Total: " + (TotalBytesDirectorySent / 1024).ToString() + "/" + (TotalBytesDirectory / 1024).ToString() + " KB";
                labelElapsed.Text = "Elapsed: " + string.Format("{0:D2}:{1:D2}:{2:D2}", elapsedSpan.Hours, elapsedSpan.Minutes, elapsedSpan.Seconds);
    
                if (progressBar1.Value != (int)((BytesTotal * 100) / FileSize))
                    progressBar1.Value = (int)((BytesTotal * 100) / FileSize);
    
                if (progressBar2.Value != (int)((TotalBytesDirectorySent * 100) / TotalBytesDirectory))
                    progressBar2.Value = (int)((TotalBytesDirectorySent * 100) / TotalBytesDirectory);
    
                if ((new TimeSpan(DateTime.Now.Ticks - updateTime).TotalMilliseconds > 200) || (TotalBytesDirectorySent == TotalBytesDirectory))
                {
                    updateTime = DateTime.Now.Ticks;
    
                    deltabytes = TotalBytesDirectorySent - deltabytes;
                    deltatime = elapsedSpan.Subtract(deltatime);
    
                    if (deltatime.Seconds > 0)
                    {
                        labelSpeed.Text = "Speed: " + (deltabytes / deltatime.Seconds / 1024).ToString() + " KB/s";
    
                        TimeSpan t = TimeSpan.FromSeconds((TotalBytesDirectory - deltabytes) / (deltabytes / deltatime.Seconds));
                        labelRemaining.Text = "Remaining: " + string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    }
                }
    
                if (BytesTotal == FileSize)
                {
                    deltabytes = 0;
                    deltatime = new TimeSpan(0);
                }
            }
    
            private long deltabytes = 0;
            private TimeSpan deltatime = new TimeSpan(0);
    
            private long updateTime = 0;
    
            private void buttonUpload_Click(object sender, EventArgs e)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    ftplib = new FTP(textBoxHost.Text, textBoxUsr.Text, textBoxPwd.Text);
    
                    ftplib.Connect();
    
                    new Thread(delegate()
                    {
                        ftplib.UploadFolderRecursively(folderBrowserDialog1.SelectedPath, ProgressEvent);
                    }).Start();
                }
            }
