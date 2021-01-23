    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private  int flag;
            FileSystemWatcher watcher = new FileSystemWatcher();
    
            public Form1()
            {
                InitializeComponent();
                watcher.Path = @"C:\";
                watcher.Filter = "test.txt";
                watcher.Changed += watcher_Changed;
                watcher.EnableRaisingEvents = true;
            }
            private void SetFlag()
            {
                FileInfo info = new FileInfo("c:\\test.txt");
                    if (info.Length > 0)  
                        flag= 1;
            }
            private void CheckFlag()
            {
                if(flag==1)
                {
                    button1.PerformClick();
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //Code for Redirection to New Form
            }            
            void watcher_Changed(object sender, FileSystemEventArgs e)
            {
                SetFlag();
                CheckFlag();
            }
        }
    }
