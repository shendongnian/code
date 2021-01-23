    System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(() =>
    {
     for (int l = 0; l < newfile.Length; l++)
     {
       vfswriter.Write(newfile[l]);
       double percentage = ((double)l / (double)newfile.Length * 100);
       //This runs the code inside it on the main thread (required for any GUI actions
       App.Current.Dispatcher.Invoke((Action) (() =>
       {
         this.progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
       }
     }
    });
    task.Start();
