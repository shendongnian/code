    private void button1_Click(object sender, EventArgs e)
    {
        //Start the listing in a task
        Task.Factory.StartNew(()=>ListAllFiles(@"C:\mmc2", ref label1));
    }
    private void ListAllFiles(string path, ref Label lbl)
    {
        string savePath = @"C:\Users\Diza\Desktop\AllFiles.txt";
        string[] files = Directory.GetFiles(path,"*.*", SearchOption.AllDirectories);
        StreamWriter myWriter = new StreamWriter(savePath);
        int count=0;
        DateTime dtStart = DateTime.Now;
        myWriter.WriteLine("Start: " + dtStart.ToShortTimeString());
        foreach (string val in files)
        {
            //update the label using the dispatcher (because ui elements cannot be accessed from an non-ui thread
            Application.Current.Dispatcher.BeginInvoke(
               new Action(()=>lbl.Text = val));
            
            myWriter.WriteLine(val);
            count++;
        }
    }
