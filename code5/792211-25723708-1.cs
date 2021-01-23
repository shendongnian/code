    ///used To Load Files And Folder information Present In Dir In dir
    private void button1_Click(object sender, EventArgs e)
        {
            FileInfo[] fileInfoArr;
            StringBuilder sbr=new StringBuilder();
            StringBuilder sbrfname = new StringBuilder();
            string strpathName = @"C:\Users\prasad\Desktop\Dll";
            DirectoryInfo dir = new DirectoryInfo(strpathName);
            fileInfoArr = dir.GetFiles("*.dll");
            
            //Load Files From RootFolder
            foreach (FileInfo f in fileInfoArr)
            {
                sbrfname.AppendLine(f.FullName);
            }
            DirectoryInfo[] dirInfos = dir.GetDirectories("*.*");
           //Load Files from folder folder 
            foreach (DirectoryInfo d in dirInfos)
            {
               fileInfoArr = d.GetFiles("*.dll");
               foreach (FileInfo f in fileInfoArr)
               {
                   sbrfname.AppendLine(f.FullName);
               }
                sbr.AppendLine(d.ToString());
                
            }
            richTextBox1.Text = sbr.ToString();
            richTextBox2.Text = sbrfname.ToString();
        }
