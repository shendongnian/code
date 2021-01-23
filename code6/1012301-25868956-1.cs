    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    { 
       var links = new[] { "link1", "link2" }; 
       var percentProgressStep = (100 / links.Length) + 1
       using (var client = new WebClient()) 
       foreach (string l in links) 
         {
           client.DownloadFile(l, Path.GetTempFileName());
           backgroundWorker1.ReportProgress(percentProgressStep);
         } 
    }
